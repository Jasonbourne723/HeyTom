using System;
using System.Collections.Generic;
using HeyTom.Application.DTO;
using HeyTom.Domain.Interface;
using HeyTom.Infra.Cache;
using HeyTom.Infra.Util;
using HeyTom.Infra.Util.Util;
using Microsoft.AspNetCore.Mvc;

namespace HeyTome.Service.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : BaseController
	{
		private readonly CsRedisBase _csRedisBase;
		private readonly IVipRepository _vipRepository;

		public RegisterController(CsRedisBase csRedisBase,
											IVipRepository vipRepository)
		{
			_csRedisBase = csRedisBase;
			_vipRepository = vipRepository;
		}
		/// <summary>
		/// 给注册邮箱发送验证码
		/// </summary>
		/// <param name="emailDTO"></param>
		/// <returns></returns>
		[Route("[action]")]
		[HttpPost]
		[ProducesResponseType(typeof(ResultModel), 200)]
		public IActionResult SendVerificationCode([FromBody] EmailDTO emailDTO)
		{
			var result = new ResultModel(1);
			return Wrapper(ref result, () => {
				var random = new Random();
				var code = random.Next(1000, 10000);
				var key = $"Register:code:Email:{emailDTO.Email}";
				_csRedisBase.set(key, code.ToString(), 60);
				var content = $"您的验证码是 ：{code},有效期60秒,请妥善保管";
				EmailUtil.Send(new List<string>() { emailDTO.Email, }, "HeyTom注册验证码", content, "HeyTom");
			}, true);
		}

		/// <summary>
		/// 注册
		/// </summary>
		/// <param name="registerInfoDTO"></param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(typeof(ResultModel), 200)]
		public IActionResult Post([FromBody] RegisterInfoDTO registerInfoDTO)
		{
			var result = new ResultModel(1);
			return Wrapper(ref result, () => {
				var key = $"Register:code:Email:{registerInfoDTO.Email}";
				var cacheCode = _csRedisBase.Get(key);
				if (cacheCode == null || cacheCode != registerInfoDTO.Code)
				{
					result.ResultNo = -1;
					result.Message = "验证码错误或已过期";
					return;
				}
				//密码加密
				registerInfoDTO.Password = MD5Util.GenerateMD5(registerInfoDTO.Password);
				_vipRepository.Add(new HeyTom.Domain.Models.Vip()
				{
					Email = registerInfoDTO.Email,
					PassWord = registerInfoDTO.Password,
					NickName = registerInfoDTO.NickName
				});
			}, true);
		}
	}
}