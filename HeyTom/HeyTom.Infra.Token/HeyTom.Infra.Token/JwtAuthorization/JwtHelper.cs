using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace HeyTom.Infra.Token.JwtAuthorization
{
	/*"Audience": {
    "Secret": "sdfsdfsrty45634kkhllghtdgdfss345t678fs",
    "Issuer": "Blog.Core",
    "Audience": "wr"
  }*/
	public class JwtHelper
	{
		/// <summary>
		/// 颁发JWT字符串
		/// </summary>
		/// <param name="tokenModel"></param>
		/// <returns></returns>
		public static string IssueJwt(TokenModelJwt tokenModel)
		{
			string iss = "wr";
			string aud = "Blog.Core";
			string secret = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";
			//var aa = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
			var claims = new List<Claim>() {
				new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),
				new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
				new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                //这个就是过期时间，目前是过期1000秒，可自定义，注意JWT有自己的缓冲过期时间
                new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(2000)).ToUnixTimeSeconds()}"),
				new Claim(JwtRegisteredClaimNames.Iss,iss),
				new Claim(JwtRegisteredClaimNames.Aud,aud),
				new Claim("Name",tokenModel.Name)
			};
			claims.AddRange(tokenModel.Role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var jwt = new JwtSecurityToken(issuer: iss, claims: claims, signingCredentials: creds);
			var jwtHander = new JwtSecurityTokenHandler();
			var encodeJwt = jwtHander.WriteToken(jwt);
			return encodeJwt;
		}


		/// <summary>
		/// 获取基于JWT的Token
		/// </summary>
		/// <param name="claims">需要在登陆的时候配置</param>
		/// <param name="permissionRequirement">在startup中定义的参数</param>
		/// <returns></returns>
		public static dynamic BuildJwtToken(Claim[] claims, PermissionRequirement permissionRequirement)
		{
			var now = DateTime.Now;
			// 实例化JwtSecurityToken
			var jwt = new JwtSecurityToken(
				issuer: permissionRequirement.Issuer,
				audience: permissionRequirement.Audience,
				claims: claims,
				notBefore: now,
				expires: now.Add(permissionRequirement.Expiration),
				signingCredentials: permissionRequirement.SigningCredentials
			);
			// 生成 Token
			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			//打包返回前台
			var responseJson = new
			{
				success = true,
				token = encodedJwt,
				expires_in = permissionRequirement.Expiration.TotalSeconds,
				token_type = "Bearer"
			};
			return responseJson;
		}

		/// <summary>
		/// 解析
		/// </summary>
		/// <param name="jwtStr"></param>
		/// <returns></returns>
		public static void SerializeJwt(string jwtStr)
		{
			var jwtHander = new JwtSecurityTokenHandler();
			var jwtToken = jwtHander.ReadJwtToken(jwtStr);

		}
	}
}
