using AutoMapper;
using HeyTom.Application.ViewModels;
using HeyTom.Domain.Models;

namespace HeyTom.Application.AutoMapper
{
	public class VOToDOPrfile : Profile
	{
		public VOToDOPrfile()
		{
			CreateMap<VipVO, Vip>();
			CreateMap<CatVO, Cat>();
			CreateMap<SimpleSayVO, SimpleSay>();
			CreateMap<PhotoVO, Photo>();
		}
	}
}
