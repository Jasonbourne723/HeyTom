using System.Collections.Generic;
using HeyTom.Domain.Models;

namespace HeyTom.Domain.Interface
{
	public interface IPhotoRepository : IRepository<Photo>
	{
		List<Photo> GetByVipId(long vipId);
	}
}
