using System;
using System.Collections.Generic;

namespace HeyTom.Domain.Models
{
	/// <summary>
	/// 社区动态
	/// </summary>
	public class SimpleSay : Entity
	{
		public SimpleSay(long vipId, string body, DateTime createTime)
		{
			VipId = vipId;
			Body = body;
			CreateTime = createTime;
		}

		public long VipId { get; private set; }

		public string Body { get; private set; }

		public DateTime CreateTime { get; private set; }
	}
}
