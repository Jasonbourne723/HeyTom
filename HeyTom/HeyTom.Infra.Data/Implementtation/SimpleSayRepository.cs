using System.Collections.Generic;
using System.Linq;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;
using HeyTom.Infra.DataContext;
using HeyTom.Infra.Implementation;

namespace HeyTom.Infra.Implementtation
{
	public class SimpleSayRepository : Repository<SimpleSay>, ISimpleSayRepository
	{
		public SimpleSayRepository(DataContext.HeyTomContext baseDbContext) : base(baseDbContext)
		{
		}

		public List<SimpleSay> GetByVipId(long vipId)
		{
			return _set.Where(x => x.VipId == vipId)?.ToList();
		}

		public override string GetTableName()
		{
			return "Vip_SimpleSay";
		}
	}
}
