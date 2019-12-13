using System.Collections.Generic;

namespace HeyTom.Infra.Util
{
	public class ListParam
	{
		public ListParam()
		{
			Sort = new List<SortModel>();
			Filter = new List<FilterModel>();
			Select = new List<SelectModel>();
		}

		public int PageIndex { get; set; }

		public int PageSize { get; set; }

		public List<SortModel> Sort { get; set; }

		public List<FilterModel> Filter { get; set; }

		public List<SelectModel> Select { get; set; }
	}
}
