using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HeyTom.Application.ViewModels;
using HeyTom.Infra.Cache;
using HeyTom.Infra.Token.Authorization;
using HeyTom.Infra.Token.JwtAuthorization;
using HeyTom.Infra.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeyTome.Service.Api.Controllers
{
	[Route("api/[controller]")]
	public class LoginController : BaseController
	{
		public LoginController(PermissionRequirement permissionRequirement)
		{
			this._permissionRequirement = permissionRequirement;
		}

		private static List<User> _users = new List<User>()
		{
			new User(){ userName = "tanglei",password = "123"}
		};
		private readonly PermissionRequirement _permissionRequirement;

		[HttpGet]
		[ProducesResponseType(typeof(TokenVO), 200)]
		[Route("[action]")]
		[AuthenticationActionNoAttribute]
		public IActionResult Get(string userName,string password,string url)
		{
			var result = new ResultModel(1);
			return this.Wrapper(ref result, () => {
				var user = _users.FirstOrDefault(x => x.userName == userName && x.password == password);
				if (user != null)
				{
					var token = Guid.NewGuid().ToString("N");
					result = new TResultModel<TokenVO>(1) {
						TModel = new TokenVO() {
							Token = token
						}
					};
					LocalCache.Set<User>(token, user);
				}
				else
				{
					result.ResultNo = -1;
					result.Message = "用户名或密码错误";
				}
			}, false);
		}


		[HttpGet]
		[ProducesResponseType(typeof(TokenVO), 200)]
		[Route("[action]")]
		[AuthenticationActionNoAttribute]
		public IActionResult Token()
		{
			TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = "Admin,Client",Name = "唐磊" };
			//var jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
			//JwtHelper.SerializeJwt(jwtStr);

			var jwtStr = JwtHelper.BuildJwtToken(new System.Security.Claims.Claim[2]{
				new System.Security.Claims.Claim(ClaimTypes.Role,"Admin"),
				new System.Security.Claims.Claim("Name","Tanglei"),
			}, _permissionRequirement);
			var suc = true;
			return Ok(new
			{
				success = suc,
				token = jwtStr
			});
		}
	}

	 
}