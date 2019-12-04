using System.Linq;
using HeyTom.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using HeyTom.Domain.Models;
using HeyTom.Application.Interface;

namespace HeyTom.UI.Web.Controllers
{
	[Route("[Controller]")]
	public class VipController : Controller
	{
		private readonly IVipService _vipService;
		private readonly ICatRepository _catRepository;
		private readonly IPhotoRepository _photoRepository;
		private readonly ISimpleSayRepository _simpleSayRepository;

		public VipController(IVipService vipService,
									ICatRepository catRepository,
									IPhotoRepository photoRepository,
									ISimpleSayRepository simpleSayRepository)
		{
			_vipService = vipService;
			_catRepository = catRepository;
			_photoRepository = photoRepository;
			_simpleSayRepository = simpleSayRepository;
		}

		[Route("[Action]")]
		public IActionResult PersonalInfo(long vipId)
		{
			var vip = _vipService.GetVipById(vipId);
			var photos = _photoRepository.GetByVipId(vipId);
			var simpleSays = _simpleSayRepository.GetByVipId(vipId);
			simpleSays?.ForEach(ea =>
			{
				//ea.Photos = photos?.FindAll(x => x.SimpleSayId == ea.Id);
			});

			ViewData["vip"] = vip;
			ViewData["photos"] = photos;
			ViewData["simpleSays"] = simpleSays;
			return View("VipPersonalInfo");
		}
	}
}