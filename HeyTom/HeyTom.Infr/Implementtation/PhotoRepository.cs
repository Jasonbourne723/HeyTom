using System.Collections.Generic;
using System.Linq;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;
using HeyTom.Infra.DataContext;
using HeyTom.Infra.Implementation;

namespace HeyTom.Infra.Implementtation
{
	public class PhotoRepository : Repository<Photo>, IPhotoRepository
	{
		public PhotoRepository(BaseDbContext baseDbContext) : base(baseDbContext)
		{
		}

		public List<Photo> GetByVipId(long vipId)
		{
			return _set.Where(x => x.VipId == vipId)?.ToList();
		}

		public override string GetTableName()
		{
			return "Vip_Photo";
		}
	}
}
