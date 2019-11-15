using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Model;
using HeyTom.DomainCore.Implementation;
using HeyTom.DomainCore.Interface;
using HeyTom.Infr.Dal;

namespace HeyTom.Infr
{
	public class VipRepository : Repository<Vip>, IVipRepository
	{
		public VipRepository(BaseDbContext baseDbContext) : base(baseDbContext)
		{
		}

		public List<Vip> GetNewVips(int count)
		{
			return _set.Take(9).ToList();
		}

		public Vip GetByVipId(long vipId)
		{
			return _set.SingleOrDefault(x => x.VipId == vipId);
		}
	}
}
