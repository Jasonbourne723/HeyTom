using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HeyTom.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HeyTom.Infra.Ioc
{
	/// <summary>
	/// automapper
	/// </summary>
	public static class AutoMapperInjection
	{
		public static IServiceCollection AddAuoMapper(this IServiceCollection services)
		{
			return services.AddAutoMapper(typeof(VOToDOPrfile))
				.AddAutoMapper(typeof(DOToVOPrfile));
		}
	}
}
