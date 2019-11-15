using System;
using System.Collections.Generic;

namespace HeyTom.Domain.Model
{
	public class SimpleSay
	{
		public long SimpleSayId { get; set; }

		public long VipId { get; set; }

		public string Body { get; set; }

		public DateTime CreateTime { get; set; }

		public List<Photo> Photos { get; set; }
	}

	public class Photo
	{
		//	Photo BIGINT(20) not NULL auto_increment PRIMARY KEY,
		//SimpleSayId BIGINT(20) not NULL DEFAULT 0,
		//VipId BIGINT(20) NOT NULL DEFAULT 0,
		//PhotoUrl
		public long PhotoId { get; set; }

		public long SimpleSayId { get; set; }

		public long VipId { get; set; }

		public string PhotoUrl { get; set; }
	}
}
