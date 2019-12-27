using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using HeyTom.Application.ViewModels;
using HeyTom.Domain.Interface;
using HeyTom.Infra.Cache;
using HeyTom.Infra.Token.Authorization;
using HeyTom.Infra.Token.JwtAuthorization;
using HeyTom.Infra.Util;
using HeyTom.Infra.Util.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HeyTome.Service.Api.Controllers
{
	/// <summary>
	/// 登录
	/// </summary>
	[Route("api/[controller]")]
	public class LoginController : BaseController
	{
		public LoginController(PermissionRequirement permissionRequirement,
									IVipRepository vipRepository)
		{
			_permissionRequirement = permissionRequirement;
			_vipRepository = vipRepository;
		}

		private static List<User> _users = new List<User>()
		{
			new User(){ userName = "tanglei",password = "123"}
		};
		private readonly PermissionRequirement _permissionRequirement;
		private readonly IVipRepository _vipRepository;

		/// <summary>
		/// 登录
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <param name="url"></param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(TokenVO), 200)]
		public IActionResult Get(string userName, string password, string url)
		{
			var result = new ResultModel(1);
			return Wrapper(ref result, () => {
				var user = _users.FirstOrDefault(x => x.userName == userName && x.password == password);
				if (user != null)
				{
					var token = Guid.NewGuid().ToString("N");
					result = new TResultModel<TokenVO>(1)
					{
						TModel = new TokenVO()
						{
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

		/// <summary>
		/// 获取token
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(TokenVO), 200)]
		[Route("[action]")]
		public IActionResult Token(string email, string password, string url)
		{
			var result = new TResultModel<TokenVO>(1);
			return Wrapper(ref result, () => {

				password = MD5Util.GenerateMD5(password);
				var vip = _vipRepository.GetVip(email, password);


				if (vip != null)
				{
					var jwtStr = JwtHelper.BuildJwtToken(new Claim[3]{
							new Claim(ClaimTypes.Role,"Admin"),
							new Claim("Name",vip.NickName),
							new Claim("Id",vip.Id.ToString())
						}, _permissionRequirement);
					result.TModel = new TokenVO()
					{
						Token = jwtStr
					};
				}
				else
				{
					result.ResultNo = -1;
				}
			}, false);
		}

		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(typeof(UserInfo), 200)]
		[Route("[action]")]
		[Authorize]
		public IActionResult GetUserInfo()
		{
			var result = new TResultModel<UserInfo>(1);
			return Wrapper(ref result, () => {
				var token = HttpContext.Request.Headers["Authorization"];
				var payload = JwtHelper.SerializeJwt(token);
				var userInfo = new UserInfo();

				payload.TryGetValue(ClaimTypes.Role, out var role);
				payload.TryGetValue("Name", out var name);
				payload.TryGetValue("Id",out object Id);

				result.TModel = new UserInfo()
				{
					Name = name.ToString(),
					Role = role.ToString(),
					Id = int.Parse(Id.ToString())
				};
			}, false);
		}

		/// <summary>
		/// github登录回调
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(TokenVO), 200)]
		[Route("[action]")]
		public IActionResult GitHubCallBcak(string code)
		{
			var result = new TResultModel<TokenVO>(1);
			return Wrapper(ref result, () => {
				var clientId = "f1f3420ef57e2d2a089d";
				var clientSecret = "4c25c6af2c4ac119b606ea18445f5745506d87cb";
				var url = $@"https://github.com/login/oauth/access_token?client_id={clientId}&client_secret={clientSecret}&code={code}";
				var tokenResponse = HeyTom.Infra.Util.Http.HttpClient.Post(url, "", header: new Dictionary<string, string>() { { "accept", "application/json" } });
				var tokenData = JsonConvert.DeserializeObject<TokenData>(tokenResponse);
				var accessToken = $"token  {tokenData.access_token}";
				var userUrl = "https://api.github.com/user";
				var UserResult = HeyTom.Infra.Util.Http.HttpClient.Get(userUrl, accessToken);
				var gitInfo = JsonConvert.DeserializeObject<GitHubUserInfo>(UserResult);

				var jwtStr = JwtHelper.BuildJwtToken(new Claim[2]{
							new Claim(ClaimTypes.Role,"Admin"),
							new Claim("Name",gitInfo.login),
						}, _permissionRequirement);
				result.TModel = new TokenVO()
				{
					Token = jwtStr
				};
			}, false);
		}
	}

	public class TokenData
	{
		/*{
    "access_token": "c170d72df2cca02bb22da7e7bbc64479500634cc",
    "token_type": "bearer",
    "scope": ""
	}*/
		public string access_token { get; set; }

		public string token_type { get; set; }

		public string scope { get; set; }
	}

	public class GitHubUserInfo
	{
		//"login": "Zaijianlixiangtl",
		//"id": 42246531,
		public string login { get; set; }
		public long id { get; set; }

		public string name { get; set; }

		/*"login": "Zaijianlixiangtl",
    "id": 42246531,
    "node_id": "MDQ6VXNlcjQyMjQ2NTMx",
    "avatar_url": "https://avatars1.githubusercontent.com/u/42246531?v=4",
    "gravatar_id": "",
    "url": "https://api.github.com/users/Zaijianlixiangtl",
    "html_url": "https://github.com/Zaijianlixiangtl",
    "followers_url": "https://api.github.com/users/Zaijianlixiangtl/followers",
    "following_url": "https://api.github.com/users/Zaijianlixiangtl/following{/other_user}",
    "gists_url": "https://api.github.com/users/Zaijianlixiangtl/gists{/gist_id}",
    "starred_url": "https://api.github.com/users/Zaijianlixiangtl/starred{/owner}{/repo}",
    "subscriptions_url": "https://api.github.com/users/Zaijianlixiangtl/subscriptions",
    "organizations_url": "https://api.github.com/users/Zaijianlixiangtl/orgs",
    "repos_url": "https://api.github.com/users/Zaijianlixiangtl/repos",
    "events_url": "https://api.github.com/users/Zaijianlixiangtl/events{/privacy}",
    "received_events_url": "https://api.github.com/users/Zaijianlixiangtl/received_events",
    "type": "User",
    "site_admin": false,
    "name": null,
    "company": "四威数据中心",
    "blog": "",
    "location": "深圳罗湖",
    "email": null,
    "hireable": null,
    "bio": "加油",
    "public_repos": 8,
    "public_gists": 0,
    "followers": 0,
    "following": 0,
    "created_at": "2018-08-09T15:40:46Z",
    "updated_at": "2019-12-19T05:14:28Z"*/
	}
}