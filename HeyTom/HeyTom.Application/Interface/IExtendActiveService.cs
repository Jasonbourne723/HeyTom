using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Model;

namespace HeyTom.Application.Interface
{
	public interface IExtendActiveService
	{
		List<ExtendBanner> GetExtendBanners();
	}
}
