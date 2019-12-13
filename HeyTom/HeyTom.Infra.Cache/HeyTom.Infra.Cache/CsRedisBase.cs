using System;
using System.Collections.Generic;
using System.Text;
using CSRedis;

namespace HeyTom.Infra.Cache
{
	public  class CsRedisBase
	{
		RedisClient _client;
		public CsRedisBase()
		{
			var host = "Cebsaas2015@120.79.8.60";
			var port = 9000;
			_client = new RedisClient(host,port);
		}

		public RedisClient GetClient()
		{
			return _client;
		}
	}
}
