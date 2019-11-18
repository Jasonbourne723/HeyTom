using System;

namespace HeyTom.Domain.Models
{
	public class Cat : Entity
	{
		public Cat(long vipId, string name, DateTime birthday, string icon, short sex, long breedId)
		{
			VipId = vipId;
			Name = name;
			Birthday = birthday;
			Icon = icon;
			Sex = sex;
			BreedId = breedId;
		}
		public long VipId { get;private set; }

		public string Name { get; private set; }

		public DateTime Birthday { get; private set; }

		public string Icon { get; private set; }

		public short Sex { get; private set; }

		public long BreedId { get; private set; }
	}
}
