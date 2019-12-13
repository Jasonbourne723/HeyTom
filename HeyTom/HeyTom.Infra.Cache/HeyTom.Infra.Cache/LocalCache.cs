using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HeyTom.Infra.Cache
{
	public static class LocalCache
	{
		private readonly static Dictionary<string, string> dic = new Dictionary<string, string>();

		public static void Set<T>(string key, T value)
		{
			var valueStr = JsonConvert.SerializeObject(value);
			dic.Add(key, valueStr);
		}

		public static T Get<T>(string key)
		{
			if (dic == null) return default(T);

			var value = dic[key];
			if (value == null) return default(T);
			return JsonConvert.DeserializeObject<T>(value);
		}
	}
}
