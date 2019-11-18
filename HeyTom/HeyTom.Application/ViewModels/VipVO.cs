using System;
using System.Collections.Generic;

namespace HeyTom.Application.ViewModels
{
	public class VipVO
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Mobile { get; set; }
		public string NickName { get; set; }
		public DateTime Birthday { get; set; }
		public string Mark { get; set; }
		public short Sex { get; set; }
		public string Province { get; set; }
		public string City { get; set; }
		public string Address { get; set; }

		public List<CatVO> Cats { get; set; }
	}
}
