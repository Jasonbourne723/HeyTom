using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;

namespace HeyTom.Infra.Cache
{
	public class RedisBase
	{
		
	}

	public class RedisManage
	{
		private PooledRedisClientManager prcm;

		public void Create()
		{
			prcm = new PooledRedisClientManager();
		}
	}
}
