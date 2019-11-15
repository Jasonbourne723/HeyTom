using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTom.Application.Interface;
using HeyTom.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HeyTom.UI.Web.Controllers
{
	[Route("[Controller]")]
	public class VipController : Controller
    {
		private readonly IVipRepository _vipService;
		private readonly ICatRepository _catRepository;
		private readonly IPhotoRepository _photoRepository;
		private readonly ISimpleSayRepository _simpleSayRepository;

		public VipController(IVipRepository vipService,
									ICatRepository catRepository,
									IPhotoRepository photoRepository,
									ISimpleSayRepository simpleSayRepository)
		{
			this._vipService = vipService;
			this._catRepository = catRepository;
			this._photoRepository = photoRepository;
			this._simpleSayRepository = simpleSayRepository;
		}

		[Route("[Action]")]
        public IActionResult PersonalInfo(long vipId)
        {
			var vip = _vipService.GetByVipId(vipId);
			var cats = _catRepository.GetByVipId(vipId);
			var photos = _photoRepository.GetByVipId(vipId);
			var simpleSays = _simpleSayRepository.GetByVipId(vipId);
			simpleSays?.ForEach(ea =>
			{
				ea.Photos = photos?.FindAll(x=>x.SimpleSayId == ea.SimpleSayId);
			});
		
			ViewData["vip"] = vip;
			ViewData["cats"] = cats;
			ViewData["photos"] = photos;
			ViewData["simpleSays"] = simpleSays;
			return View("VipPersonalInfo");
        }
    }
}