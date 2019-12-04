using System;

namespace HeyTom.Infra.MessageQueue.RabbitMq
{
	public class RabbitMqAttribute : Attribute
	{
		public RabbitMqAttribute(string exChangeName, string queueName, string exchangeType = "direct", string routingKey = "")
		{
			ExChangeName = exChangeName;
			QueueName = queueName;
			RoutingKey = routingKey;
			ExchangeType = exchangeType;
		}

		public string ExChangeName { get; set; }

		public string QueueName { get; set; }

		public string RoutingKey { get; set; }

		public string ExchangeType { get; set; }
	}
}
