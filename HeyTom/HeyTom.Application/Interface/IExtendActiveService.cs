using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Models;

namespace HeyTom.Application.Interface
{
	public interface IExtendActiveService
	{
		List<ExtendBanner> GetExtendBanners();
	}
}
