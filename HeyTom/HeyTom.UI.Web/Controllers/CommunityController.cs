using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTom.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HeyTom.UI.Web.Controllers
{
    public class CommunityController : Controller
    {
		private readonly IVipService _vipService;

		public CommunityController(IVipService vipService)
		{
			this._vipService = vipService;
		}

		public IActionResult Index()
        {
			ViewData["NewVips"]  = _vipService.GetNewVips(9);

			return View("Community");
        }
    }
}