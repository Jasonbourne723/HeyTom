using System.Collections.Generic;
using HeyTom.Application.Interface;
using HeyTom.Application.ViewModels;
using HeyTom.Infra.Util;
using Microsoft.AspNetCore.Mvc;

namespace HeyTome.Service.Api.Controllers
{
	/// <summary>
	/// vip controller
	/// </summary>
	[Route("api/[controller]")]
	public class VipController : BaseController
	{
		private Dictionary<string, string> dicVip = new Dictionary<string, string>() {
			{ "Id","Id"},
			{ "NickName","NickName"},
			{ "Icon","Icon"}
		};

		private readonly IVipService _vipService;

		public VipController(IVipService vipService)
		{
			this._vipService = vipService;
		}

		/// <summary>
		/// Get Vips
		/// </summary>
		/// <param name="viewParam"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("[action]")]
		[ProducesResponseType(typeof(List<SimpleVipVO>), 200)]
		public IActionResult List([FromBody]ViewParam viewParam)
		{
			var result = new ResultModel(200);
			return Wrapper( ref result, () =>
			{
				var listParam = ConvertRequest.Convert(viewParam, dicVip);
				result = _vipService.GetViewPager(listParam);
			}, false);
		}
	}
}