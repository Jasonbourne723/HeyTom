using System.Collections.Generic;
using HeyTom.Domain.Models;

namespace HeyTom.Domain.Interface
{
	public interface ISimpleSayRepository : IRepository<SimpleSay>
	{
		List<SimpleSay> GetByVipId(long vipId);
	}
}
