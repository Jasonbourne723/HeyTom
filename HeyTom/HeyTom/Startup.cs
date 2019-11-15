﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTom.Application.Implementation;
using HeyTom.Application.Interface;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Model;
using HeyTom.Infr;
using HeyTom.Infr.Dal;
using HeyTom.Infr.Implementtation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HeyTom
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<BaseDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("Default")));
			services.AddScoped<IExtendBannerRepository, ExtendBannerRepository>();
			services.AddScoped<ICatRepository, CatRepository>();
			services.AddScoped<IVipRepository, VipRepository>();
			services.AddScoped<ISimpleSayRepository, SimpleSayRepository>();
			services.AddScoped<IPhotoRepository, PhotoRepository>();
			services.AddScoped<IExtendActiveService, ExtendActiveService>();
			services.AddScoped<IVipService, VipService>();
		
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
