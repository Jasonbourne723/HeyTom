using System;
using System.Collections.Generic;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;

namespace HeyTom.Infra.Implementtation
{
	public class ExtendBannerRepository : IExtendBannerRepository
	{
		public List<ExtendBanner> GetAll()
		{
			var list = new List<ExtendBanner>()
			{
				new ExtendBanner("https://static.runoob.com/images/mix/img_fjords_wide.jpg","HeyTom盖楼活动",""),
				new ExtendBanner("https://static.runoob.com/images/mix/img_nature_wide.jpg","寄养家庭排行榜",""),
				new ExtendBanner("https://static.runoob.com/images/mix/img_mountains_wide.jpg","问卷调查",""),
			};
			return list;
		}
	}
}
