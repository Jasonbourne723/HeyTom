using System;
using HeyTom.Infra.Cache;
using HeyTom.Infra.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace HeyTom.Infra.Token.Authorization
{
	public class AuthenticationActionAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var result = new ResultModel(1);
			var controller = (context.Controller as BaseController);
			try
			{
				if (controller != null && controller._authType)
				{
					var headers = context.HttpContext.Request.Headers;
					if (!headers.ContainsKey("Authorization"))
					{
						throw new Exception("无权限");
					}
					var tokenStr = headers["Authorization"].ToString();
					if (!tokenStr.StartsWith("Bearer "))
					{
						throw new Exception("无权限");
					}
					tokenStr = tokenStr.Substring("Bearer ".Length).Trim();
					var user = LocalCache.Get<User>(tokenStr);
					if (user == null)
					{
						throw new Exception("无权限");
					}
				}
				base.OnActionExecuting(context);
			}
			catch (Exception ex)
			{
				result.ResultNo = -1;
				result.Message = "无权限";
				var contenResult = new ContentResult();
				contenResult.Content = JsonConvert.SerializeObject(result);
				contenResult.ContentType = "application/json;charset=utf-8";
				context.Result = contenResult;
			}
		}
	}
}
