using System;
using System.Collections.Generic;
using System.Text;
using CSRedis;
using Newtonsoft.Json;

namespace HeyTom.Infra.Cache
{
	public   class CsRedisBase
	{
		RedisClient _client;
		public CsRedisBase()
		{
			var host = "192.168.124.16";
			var port = 6379;
			_client = new RedisClient(host,port);
		}

		public void set(string key, string value)
		{
			_client.Set(key, value);
		}

		public void set<T>(string key,T value) where T:class,new()
		{
			var str = JsonConvert.SerializeObject(value);
			_client.Set(key, str);
		}

		public void set(string key, string value, int expiration)
		{
			_client.Set(key, value, expiration);
		}
		public void set<T>(string key, T value,int expiration) where T:class,new()
		{
			var str = JsonConvert.SerializeObject(value);
			_client.Set(key, str, expiration);
		}

		public string Get(string key)
		{
			return _client.Get(key);
		}

		public T Get<T>(string key)
		{
			var str =  _client.Get(key);
			return JsonConvert.DeserializeObject<T>(str);
		}

	}
}
