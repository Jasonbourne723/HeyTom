using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeyTom.UI.Web.Controllers
{
	[Route("[Controller]")]
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View("Login");
		}
		[Route("[action]")]
		[HttpGet]
		public IActionResult Login(string userName,string pwd)
		{
			if (userName == "aa" && pwd == "bb")
			{
				SignIn(new System.Security.Claims.ClaimsPrincipal(), "");
				return Redirect("/Home");
			}
			return Ok(200);
		}

		[Route("[action]")]
		public IActionResult GitHub()
		{
			var clientId = "f1f3420ef57e2d2a089d";
			var clientSecret = "4c25c6af2c4ac119b606ea18445f5745506d87cb";
			return Redirect("https://github.com/login/oauth/authorize?client_id=f1f3420ef57e2d2a089d&redirect_uri=http://localhost:62526/oath/callback");
		}
	}
}