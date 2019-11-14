using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Model;
using HeyTom.DomainCore.Implementation;
using HeyTom.DomainCore.Interface;
using HeyTom.Infr.Dal;

namespace HeyTom.Infr
{
	public class VipRepository : Repository<Vip>, IVipRepository
	{
		public VipRepository(VipDbContext baseDbContext) : base(baseDbContext)
		{
			
		}

		public List<Vip> GetNewVips(int count)
		{
			return _baseDbContext.List.ToList();

			//return new List<Vip>()
			//{
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3090286133,3354461826&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3090286133,3354461826&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3090286133,3354461826&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3090286133,3354461826&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3090286133,3354461826&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=2936261972,618644309&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3090286133,3354461826&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=2936261972,618644309&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//	new Vip(){ vipId = 1,name = "jason",icon= "http://mmbiz.qpic.cn/mmbiz_jpg/We2xHH8rmewBI23YvQNcyrzvlbyLzbyYJUh4Wicbgib0Efe2bgqLPpoVeLV0pHxiawU5m4xZic7Iia3xeiaG5llNPz0A/0?wx_fmt=jpeg",
			//	mobile = "16675566723",adress = new Adress{ province="黑龙江",city="哈尔滨",detailAdress="道里区"},cat = new Cat(){
			//		name = "Tom",birthday = DateTime.Now,icon = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3090286133,3354461826&fm=26&gp=0.jpg",sex = "男"
			//	} },
			//}.Take(count).ToList();
		}
	}
}
