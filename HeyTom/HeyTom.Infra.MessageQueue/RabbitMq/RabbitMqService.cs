using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeyTom.Infra.Util;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HeyTom.Infra.MessageQueue.RabbitMq
{
	/// <summary>
	/// rabbitMq服务
	/// </summary>
	public class RabbitMqService : IRabbitMqService
	{
		private IConnection _cnn;

		private static readonly ConcurrentDictionary<string, IModel> _dicChannel = new ConcurrentDictionary<string, IModel>();
		private readonly IConfiguration _configuration;

		public RabbitMqService(IConfiguration configuration)
		{
			_configuration = configuration;
			Open();
		}
		/// <summary>
		/// 创建连接
		/// </summary>
		private void Open()
		{
			var section = _configuration.GetSection("RabbitMq");
			var factory = new ConnectionFactory()
			{
				HostName = section["Host"],
				Port = int.Parse(section["Port"]),
				UserName = section["UserName"],
				Password = section["Password"]
			};
			_cnn = factory.CreateConnection();
			factory.AutomaticRecoveryEnabled = true;
			factory.NetworkRecoveryInterval = new TimeSpan(0, 0, 10);
		}
		/// <summary>
		/// 创建通道
		/// </summary>
		/// <param name="exchange"></param>
		/// <param name="queue"></param>
		/// <param name="routingKey"></param>
		/// <param name="exchangeType"></param>
		/// <param name="exChangeArg"></param>
		/// <param name="queueArg"></param>
		/// <returns></returns>
		private IModel GetModel(string exchange, string queue, string routingKey, string exchangeType = "fanout", Dictionary<string, object> exChangeArg = null, Dictionary<string, object> queueArg = null)
		{
			return _dicChannel.GetOrAdd(queue, ea => {
				var channel = _cnn.CreateModel();
				channel.ExchangeDeclare(exchange, exchangeType, true, false, exChangeArg);
				channel.QueueDeclare(queue, true, false, false, queueArg);
				channel.QueueBind(queue, exchange, routingKey);
				return channel;
			});
		}
		/// <summary>
		/// 获取特性
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private RabbitMqAttribute GetRabbitMqAttribute<T>()
		{
			var tType = typeof(T);
			return tType.GetCustomAttributes(typeof(RabbitMqAttribute), false)?.FirstOrDefault() as RabbitMqAttribute;
		}
		/// <summary>
		/// 发布消息
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <returns></returns>
		public ResultModel Publish<T>(T entity)
		{
			var result = new ResultModel(1);
			var attribute = GetRabbitMqAttribute<T>();
			var exChangeName = attribute.ExChangeName;
			var queueName = attribute.QueueName;
			var routingKey = attribute.RoutingKey;
			var exChangeType = attribute.ExchangeType;
			var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entity));

			try
			{
				var channel = GetModel(exChangeName, queueName, routingKey, exChangeType);
				var properties = channel.CreateBasicProperties();
				properties.DeliveryMode = 2;
				channel.BasicPublish(exChangeName, routingKey, properties, body);
			}
			catch (Exception ex)
			{
				result.ResultNo = -1;
				result.Message = ex.Message;
			}
			return result;
		}
		/// <summary>
		/// 订阅队列
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="action"></param>
		public void Subscribe<T>(Action<T> action)
		{
			var attribute = GetRabbitMqAttribute<T>();
			var exChangeName = attribute.ExChangeName;
			var queueName = attribute.QueueName;
			var routingKey = attribute.RoutingKey;
			var exChangeType = attribute.ExchangeType;

			var channel = GetModel(exChangeName, queueName, routingKey, exChangeType);
			var consumer = new EventingBasicConsumer(channel); //声明事件基本消费者
			consumer.Received += (ch, ea) => {
				var entity = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(ea.Body));
				action(entity);
				//channel.BasicAck(ea.DeliveryTag, false); //确认该消息已被消费
			};
			channel.BasicConsume(queueName, true, consumer);
		}

		public void Dispose()
		{
			foreach (var item in _dicChannel)
			{
				item.Value.Dispose();
			}
			_cnn.Dispose();
		}
	}
}
