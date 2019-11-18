using System;
using System.Collections.Generic;

namespace HeyTom.Application.ViewModels
{
	public class SimpleSayVO
	{
		public long Id { get; set; }

		public long VipId { get; set; }
		public string Body { get; private set; }

		public DateTime CreateTime { get; private set; }

		public List<PhotoVO> PhotoVOs { get; set; }
	}
}
