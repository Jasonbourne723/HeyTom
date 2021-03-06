﻿using System;
using System.Linq;
using HeyTom.Application.Implementation;
using HeyTom.Infra.Implementtation;
using HeyTom.Infra.MessageQueue;
using HeyTom.Infra.MessageQueue.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

namespace HeyTom.Infraa.Ioc
{
	public static class DependencyInjectionExtend
	{
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
		{
			services.AddSingleton<IRabbitMqService, RabbitMqService>();
			return services.Scan(scan => scan
							.FromAssemblyOf<ExtendBannerRepository>()
							.AddClasses(classes => classes.Where(x => x.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)))
							.AsImplementedInterfaces()
							.WithScopedLifetime())
					.Scan(scan => scan
						.FromAssemblyOf<VipService>()
						.AddClasses(classes => classes.Where(x => x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)))
						.AsImplementedInterfaces()
						.WithScopedLifetime());
		}
	}
}
