using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeyTom.UI.Web.Controllers
{
	[Route("[Controller]")]
    public class OathController : Controller
    {
		[HttpGet]
		[ProducesResponseType(typeof(string), 200)]
		public IActionResult Index()
        {
            return View();
        }

		[Route("[action]")]
		[HttpGet]
		[ProducesResponseType(typeof(string),200)]
		public string CallBack(string code)
		{
			return code;
		}

	}
}