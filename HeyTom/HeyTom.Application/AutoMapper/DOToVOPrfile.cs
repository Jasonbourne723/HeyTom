using AutoMapper;
using HeyTom.Application.ViewModels;
using HeyTom.Domain.Models;

namespace HeyTom.Application.AutoMapper
{
	public class DOToVOPrfile : Profile
	{
		public DOToVOPrfile()
		{
			CreateMap<Vip, VipVO>();
			CreateMap<Vip, SimpleVipVO>();
			CreateMap<Cat, CatVO>();
			CreateMap<SimpleSay, SimpleSayVO>();
			CreateMap<Photo, PhotoVO>();
		}
	}
}
