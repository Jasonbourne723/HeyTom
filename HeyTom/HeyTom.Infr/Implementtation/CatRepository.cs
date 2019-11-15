using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Model;
using HeyTom.DomainCore.Implementation;
using HeyTom.Infr.Dal;
using System.Linq;

namespace HeyTom.Infr.Implementtation
{
	public class CatRepository : Repository<Cat>, ICatRepository
	{
		public CatRepository(BaseDbContext baseDbContext) : base(baseDbContext)
		{
		}

		public List<Cat> GetByVipId(long vipId)
		{
			return _set.Where(x => x.VipId == vipId)?.ToList();
		}
	}
}
