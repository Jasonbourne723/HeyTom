using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HeyTom.Application.Interface;
using HeyTom.Application.ViewModels;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;
using HeyTom.Infra.Util;

namespace HeyTom.Application.Implementation
{
	/// <summary>
	/// 会员信息查询服务
	/// </summary>
	public class VipService : IVipService
	{
		private readonly IVipRepository _vipRepository;
		private readonly ICatRepository _catRepository;
		private readonly IMapper _mapper;

		public VipService(IVipRepository vipRepository,
								ICatRepository catRepository,
								IMapper mapper)
		{
			this._vipRepository = vipRepository;
			this._catRepository = catRepository;
			this._mapper = mapper;
		}

		/// <summary>
		/// 获取最新注册的用户基本信息
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public List<SimpleVipVO> GetNewVips(int count)
		{
			var vips =  _vipRepository.GetNewVips(count);
			return _mapper.Map<List<SimpleVipVO>>(vips);
		}

		public PagedData<SimpleVipVO> GetViewPager(ListParam param)
		{
			return _vipRepository.GetViewPager<SimpleVipVO>(param);
		}

		/// <summary>
		/// 获取会员信息(含猫咪列表)
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public VipVO GetVipById(long Id)
		{
			var vip =  _vipRepository.GetOne(Id);
			if (vip == null) return null;
			var cats = _catRepository.GetByVipId(Id);
			var vipVO = _mapper.Map<VipVO>(vip);
			vipVO.Cats = _mapper.Map<List<CatVO>>(cats);
			return vipVO;
		}
	}
}
