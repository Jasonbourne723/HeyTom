using System;
using System.Linq;
using HeyTom.Infra.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HeyTome.Service.Api.Controllers
{
	[Route("api/[controller]")]
	public abstract class BaseController : ControllerBase
	{
		public BaseController()
		{
		}

		protected IActionResult Wrapper(ref ResultModel result, Action action, bool isVaild)
		{
			if (isVaild)
			{
				if (!ModelState.IsValid)
				{
					result.ResultNo = 1;
					result.Message = ModelState.Keys.SelectMany(x => ModelState[x].Errors.Select(y => new { x, y.ErrorMessage })).ToString();
					return new ContentResult()
					{
						Content = JsonConvert.SerializeObject(result),
						ContentType = "application/json;charset=utf-8",
					};
				}
			}
			try
			{
				action();
			}
			catch (Exception ex)
			{
				result.ResultNo = -1;
				result.Message = "请求失败,请稍后重试";
			}
			return new ContentResult()
			{
				Content = JsonConvert.SerializeObject(result),
				ContentType = "application/json;charset=utf-8",
			};
		}
	}
}