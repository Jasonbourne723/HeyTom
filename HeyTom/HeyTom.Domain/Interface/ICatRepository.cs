using System.Collections.Generic;
using HeyTom.Domain.Models;

namespace HeyTom.Domain.Interface
{
	public interface ICatRepository : IRepository<Cat>
	{
		List<Cat> GetByVipId(long vipId);
	}
}
