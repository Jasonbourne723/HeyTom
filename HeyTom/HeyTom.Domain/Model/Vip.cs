using System;
using System.Collections.Generic;
using System.Text;

namespace HeyTom.Domain.Model
{
	public class Vip
	{
		public long VipId { get; set; }

		public string Name { get; set; }

		public string Icon { get; set; }

		public string Mobile { get; set; }

		public string WxOpenId { get; set; }

		public string NickName { get; set; }

		public DateTime Birthday { get; set; }

		public string Mark { get; set; }

		public short Sex { get; set; }
		public string Province { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		//public Adress adress { get; set; }

		//public Cat cat { get; set; }
	}

	public class Cat
	{
		public long CatId { get; set; }

		public long VipId { get; set; }

		public string Name { get; set; }

		public DateTime	Birthday { get; set; }

		public string Icon { get; set; }

		public short Sex { get; set; }

		public long BreedId { get; set; }
	}
}
