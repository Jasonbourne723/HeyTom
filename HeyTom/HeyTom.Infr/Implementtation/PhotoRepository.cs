using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Model;
using HeyTom.DomainCore.Implementation;
using HeyTom.Infr.Dal;

namespace HeyTom.Infr.Implementtation
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
 	}
}
