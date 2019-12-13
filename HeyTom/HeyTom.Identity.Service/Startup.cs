using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HeyTom.Identity.Service
{
	public class Startup
	{

		public IConfiguration Configuration { get; }
		public IHostingEnvironment Environment { get; }

		public Startup(IConfiguration configuration, IHostingEnvironment environment)
		{
			Configuration = configuration;
			Environment = environment;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			var builder = services.AddIdentityServer(options => {
				options.Events.RaiseErrorEvents = true;
				options.Events.RaiseInformationEvents = true;
				options.Events.RaiseFailureEvents = true;
				options.Events.RaiseSuccessEvents = true;
			})
			// in-memory, code config
			.AddTestUsers(InMemoryConfig.Users().ToList())
			.AddInMemoryApiResources(InMemoryConfig.GetApiResources())
			.AddInMemoryClients(InMemoryConfig.GetClients());


			builder.AddDeveloperSigningCredential();

			if (Environment.IsDevelopment())
			{
				builder.AddDeveloperSigningCredential();
			}
			else
			{
				throw new Exception("need to configure key material");
			}

			services.AddAuthentication();//配置认证服务

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseIdentityServer();//启动 IdentityServer
			app.UseMvcWithDefaultRoute();//启动 MVC
		}
	}
}
