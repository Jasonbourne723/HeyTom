using System;
using System.Collections.Generic;

namespace HeyTom.Infra.Util
{
	public  class ConvertRequest
	{
		public static ListParam Convert(ViewParam viewParam, Dictionary<string, string> dic)
		{
			if (viewParam == null || dic == null || dic.Count == 0)
			{
				throw new ArgumentNullException();
			}

			var listParam = new ListParam
			{
				PageIndex = viewParam.PageIndex,
				PageSize = viewParam.PageSize
			};
			
			if (viewParam.Select == null || viewParam.Select.Count == 0)
			{
				foreach (var key in dic.Keys)
				{
					listParam.Select.Add(new SelectModel()
					{
						Key = dic[key],
						Value = key
					});
				}
			}
			else
			{
				viewParam.Select?.ForEach(ea =>
				{
					if (dic.ContainsKey(ea))
					{
						listParam.Select.Add(new SelectModel()
						{
							Key = dic[ea],
							Value = ea
						});
					}
				});
			}
			viewParam.Sort?.ForEach(ea =>
			{
				if (dic.ContainsKey(ea.Field))
				{
					listParam.Sort.Add(
						new SortModel()
						{
							Field = ea.Field,
							DbField = dic[ea.Field],
							Value = ea.Value
						});
				}
			});
			viewParam.Filter?.ForEach(ea =>
			{
				if (dic.ContainsKey(ea.Field))
				{
					listParam.Filter.Add(new FilterModel()
					{
						Field = ea.Field,
						DbField = dic[ea.Field],
						Connector = ea.Connector,
						Operator = ea.Operator,
						Value = ea.Value
					});
				}
			});
			return listParam;
		}
	}
}
