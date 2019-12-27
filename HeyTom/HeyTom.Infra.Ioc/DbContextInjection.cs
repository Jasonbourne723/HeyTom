using HeyTom.Infra.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HeyTom.Infraa.Ioc
{
	public static class DbContextInjection
	{
		public static IServiceCollection AddDbContextInjection(this IServiceCollection services, IConfiguration configuration)
		{
			return services.AddDbContext<HeyTomContext>(options => options.UseMySQL(configuration.GetConnectionString("Default")));
		}
	}
}
