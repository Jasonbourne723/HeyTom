using System.Collections.Generic;
using HeyTom.Domain.Models;

namespace HeyTom.Domain.Interface
{
	public interface IVipRepository : IRepository<Vip>
	{
		List<Vip> GetNewVips(int count);

		Vip GetVip(string email, string password);
	}
}
