using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Application.Interface;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Model;

namespace HeyTom.Application.Implementation
{
	public class VipService : IVipService
	{
		private readonly IVipRepository _vipRepository;

		public VipService(IVipRepository vipRepository)
		{
			this._vipRepository = vipRepository;
		}

		public List<Vip> GetNewVips(int count)
		{
			return _vipRepository.GetNewVips(count);
		}
	}
}
