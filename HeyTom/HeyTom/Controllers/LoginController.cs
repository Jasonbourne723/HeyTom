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
	}
}