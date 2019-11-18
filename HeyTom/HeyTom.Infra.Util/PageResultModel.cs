using System;

namespace HeyTom.Infra.Util
{
	public class PageResultModel : ResultModel
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int PageCount { get {
				return (int)Math.Ceiling(((double)RecordCount / (double)PageSize));
			}}
		public long RecordCount { get; set; }
	}
}
