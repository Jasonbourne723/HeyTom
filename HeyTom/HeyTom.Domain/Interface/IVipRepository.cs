using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Model;
using HeyTom.DomainCore.Interface;

namespace HeyTom.Domain.Interface
{
	public interface IVipRepository :IRepository<Vip>
	{
		List<Vip> GetNewVips(int count);
	}
}
