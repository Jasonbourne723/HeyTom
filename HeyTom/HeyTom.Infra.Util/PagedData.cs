using System;
using System.Collections.Generic;
using System.Text;

namespace HeyTom.Infra.Util
{
	public class PagedData<T> : PageResultModel
	{
		public List<T> TModel { get; set; }
	}
}
