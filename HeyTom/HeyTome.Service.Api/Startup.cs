using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HeyTom.Infra.Ioc;
using HeyTom.Infraa.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HeyTome.Service.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public void ConfigureServices(IServiceCollection services)
		{
			//注册Swagger生成器，定义一个和多个Swagger 文档
			services.AddSwaggerGen(c =>
			{
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
				var xmlPath1 = System.IO.Path.Combine(AppContext.BaseDirectory, $"{xmlFile}");
				c.IncludeXmlComments(xmlPath1);
				c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
				{
					Title = "HeyTom",
					Version = "V1",
				});
			});
			//依赖注入
			services.AddAuoMapper()
				.AddDbContextInjection(Configuration)
				.AddDependencyInjection();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseMvc();
			//启用中间件服务生成Swagger作为JSON终结点
			app.UseSwagger();
			//启用中间件服务对swagger-ui，指定Swagger JSON终结点
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("../swagger/v1/swagger.json", "HeyTom  API");
			});
		}
	}
}
