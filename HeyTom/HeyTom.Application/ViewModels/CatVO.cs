using System;

namespace HeyTom.Application.ViewModels
{
	public class CatVO
	{
		public long Id { get; set; }

		public string Name { get; private set; }

		public DateTime Birthday { get; private set; }

		public string Icon { get; private set; }

		public short Sex { get; private set; }

		public long BreedId { get; private set; }
	}
}
