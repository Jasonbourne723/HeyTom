using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Model;
using HeyTom.DomainCore.Interface;

namespace HeyTom.Domain.Interface
{
	public interface ICatRepository :IRepository<Cat>
	{
		List<Cat> GetByVipId(long vipId);
	}
}
