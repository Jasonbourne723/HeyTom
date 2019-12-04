using System.Collections.Generic;
using System.Linq;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;
using HeyTom.Infra.DataContext;
using Microsoft.EntityFrameworkCore;

namespace HeyTom.Infra.Implementation
{
	public class VipRepository : Repository<Vip>, IVipRepository
	{
		public VipRepository(BaseDbContext baseDbContext) : base(baseDbContext)
		{
		}

		public List<Vip> GetNewVips(int count)
		{
			//return _set.FromSql("sql",)
			return _set.Take(count).OrderBy(x=>x.Id).ToList();
		}

		public override string GetTableName()
		{
			return "Vip";
		}
	}
}
