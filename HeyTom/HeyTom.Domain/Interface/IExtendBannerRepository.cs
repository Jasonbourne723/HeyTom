using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Models;

namespace HeyTom.Domain.Interface
{
	public interface IExtendBannerRepository
	{
		List<ExtendBanner> GetAll();
	}
}
