using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Application.ViewModels;
using HeyTom.Domain.Models;
using HeyTom.Infra.Util;

namespace HeyTom.Application.Interface
{
	public interface IVipService
	{
		/// <summary>
		/// 获取最新注册的用户基本信息
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		List<SimpleVipVO> GetNewVips(int count);
		/// <summary>
		/// 获取会员信息(含猫咪列表)
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		VipVO GetVipById(long Id);

		PagedData<SimpleVipVO> GetViewPager(ListParam param);

	}
}
