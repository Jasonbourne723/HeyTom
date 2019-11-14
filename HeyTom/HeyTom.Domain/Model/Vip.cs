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

	public class Adress
	{
		
	}

	public class Cat
	{
		public string name { get; set; }

		public string icon { get; set; }

		public string sex { get; set; }

		public DateTime	birthday { get; set; }
	}
}
