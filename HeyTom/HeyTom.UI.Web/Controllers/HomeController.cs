using System.Collections.Generic;
using System.Diagnostics;
using HeyTom.Application.Interface;
using HeyTom.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeyTom.UI.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IExtendActiveService _extendActiveService;

		public HomeController(IExtendActiveService extendActiveService)
		{
			_extendActiveService = extendActiveService;
		}

		public IActionResult Index()
		{
			var extendBanners = _extendActiveService.GetExtendBanners();
			ViewData["extendBanners"] = extendBanners;
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return null;
			//return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


	}
}
