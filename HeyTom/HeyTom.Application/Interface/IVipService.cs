using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Model;

namespace HeyTom.Application.Interface
{
	public interface IVipService
	{
		List<Vip> GetNewVips(int count);
	}
}
