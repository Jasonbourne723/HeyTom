using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTom.Infra.AliYunOss;
using HeyTom.Infra.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeyTome.Service.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OssController : ControllerBase
	{
		public OssController()
		{
		}


		[HttpGet]
		[ProducesResponseType(typeof(ResultModel),200)]
		public IActionResult Get()
		{
			TestSDK.Test();
			return Ok(200);
		}
	}
}