using System.Collections.Generic;

namespace HeyTom.Infra.Util
{
	public class ViewParam
	{

		public int PageIndex { get; set; }

		public int PageSize { get; set; }

		public List<SortModel> Sort { get; set; }

		public List<FilterModel> Filter { get; set; }

		public List<string> Select { get; set; }
	}
}
