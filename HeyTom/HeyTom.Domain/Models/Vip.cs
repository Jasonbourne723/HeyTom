using System;

namespace HeyTom.Domain.Models
{
	public class Vip : Entity
	{
		public Vip()
		{ }
		public Vip(string name, string icon, string mobile, string wxOpenId, string nickName, DateTime birthday, string mark, short sex, string province, string city, string address)
		{
			Name = name;
			Icon = icon;
			Mobile = mobile;
			WxOpenId = wxOpenId;
			NickName = nickName;
			Birthday = birthday;
			Mark = mark;
			Sex = sex;
			Province = province;
			City = city;
			Address = address;
		}

		public string Name { get; private set; }
		public string Icon { get; private set; }
		public string Mobile { get; private set; }
		public string WxOpenId { get; private set; }
		public string NickName { get; private set; }
		public DateTime Birthday { get; private set; }
		public string Mark { get; private set; }
		public short Sex { get; private set; }
		public string Province { get; private set; }
		public string City { get; private set; }
		public string Address { get; private set; }
	}
}
