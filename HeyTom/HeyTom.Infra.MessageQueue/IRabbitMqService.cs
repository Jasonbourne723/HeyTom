using System;
using HeyTom.Infra.Util;

namespace HeyTom.Infra.MessageQueue
{
	/// <summary>
	/// rabbitMq接口
	/// </summary>
	public interface IRabbitMqService:IDisposable
	{
		ResultModel Publish<T>(T entity);

		void Subscribe<T>(Action<T> action);
	}
}
