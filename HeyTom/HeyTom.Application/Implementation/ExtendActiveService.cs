using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Application.Interface;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;

namespace HeyTom.Application.Implementation
{
	public class ExtendActiveService : IExtendActiveService
	{
		private readonly IExtendBannerRepository _extendBannerRepository;

		public ExtendActiveService(IExtendBannerRepository extendBannerRepository)
		{
			this._extendBannerRepository = extendBannerRepository;
		}

		public List<ExtendBanner> GetExtendBanners()
		{
			return _extendBannerRepository.GetAll();
		}
	}
}
