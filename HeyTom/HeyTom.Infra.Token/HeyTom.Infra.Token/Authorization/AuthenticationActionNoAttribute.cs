using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Infra.Util;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeyTom.Infra.Token.Authorization
{
	public class AuthenticationActionNoAttribute : ActionFilterAttribute
	{
		public AuthenticationActionNoAttribute()
		{
			base.Order = -1;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			(context.Controller as BaseController)._authType = false;
			base.OnActionExecuting(context);
		}
	}
}
