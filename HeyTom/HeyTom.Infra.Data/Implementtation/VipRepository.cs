using System.Collections.Generic;
using System.Linq;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;
using HeyTom.Infra.DataContext;
using HeyTom.Infra.Util;
using Microsoft.EntityFrameworkCore;

namespace HeyTom.Infra.Implementation
{
	public class VipRepository : Repository<Vip>, IVipRepository
	{
		public VipRepository(DataContext.HeyTomContext baseDbContext) : base(baseDbContext)
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

		public Vip GetVip(string email, string password)
		{
			return  _set.FirstOrDefault(x => x.Email == email && x.PassWord == password);
		}
	}
}
