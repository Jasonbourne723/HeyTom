using System.Collections.Generic;
using System.Linq;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;
using HeyTom.Infra.DataContext;
using HeyTom.Infra.Implementation;

namespace HeyTom.Infra.Implementtation
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

		public override string GetTableName()
		{
			return "Vip_Cat";
		}
	}
}
