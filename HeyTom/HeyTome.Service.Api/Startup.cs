using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HeyTom.Infra.Cache;
using HeyTom.Infra.Ioc;
using HeyTom.Infra.Token;
using HeyTom.Infra.Token.Authorization;
using HeyTom.Infra.Token.JwtAuthorization;
using HeyTom.Infraa.Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
			var permission = new List<PermissionItem> {
							   new PermissionItem {  Url="/", Name="Admin"},
							   new PermissionItem {  Url="/api/values", Name="Admin"},
							   new PermissionItem {  Url="/", Name="system"},
							   new PermissionItem {  Url="/api/values1", Name="system"}
						 };
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("sdfsdfsrty45634kkhllghtdgdfss345t678fs")),//参数配置在下边
				ValidateIssuer = true,
				ValidIssuer = "wr",//发行人
				ValidateAudience = true,
				ValidAudience = "Blog.Core",//订阅人
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				RequireExpirationTime = true,
			};
			var permissionRequirement = new PermissionRequirement(
				"/api/denied",// 拒绝授权的跳转地址（目前无用）
				permission,//这里还记得么，就是我们上边说到的角色地址信息凭据实体类 Permission
				ClaimTypes.Role,//基于角色的授权
				"wr",//发行人
				"Blog.Core",//订阅人
				 new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("sdfsdfsrty45634kkhllghtdgdfss345t678fs")), SecurityAlgorithms.HmacSha256),//签名凭据
				expiration: TimeSpan.FromSeconds(20)//接口的过期时间，注意这里没有了缓冲时间，你也可以自定义，在上边的TokenValidationParameters的 ClockSkew
				);
			//注册Swagger生成器，定义一个和多个Swagger 文档
			services.AddSwaggerGen(c => {
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
				var xmlPath1 = System.IO.Path.Combine(AppContext.BaseDirectory, $"{xmlFile}");
				c.IncludeXmlComments(xmlPath1);
				c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
				{
					Title = "HeyTom",
					Version = "V1",
				});
			});
			services.AddSingleton<CsRedisBase>();
			services.AddAuthentication(x => {
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(o => {
				 o.TokenValidationParameters = tokenValidationParameters;
			 });
			services.AddAuthorization(options => {
				//options.AddPolicy("Permission", policy => policy.Requirements.Add(permissionRequirement));
			});
			
			
			//services.AddSingleton<IMemoryCache>(factory => {
			//	var cache = new MemoryCache(new MemoryCacheOptions());
			//	return cache;
			//});
			//services.AddAuthorization(options => {
			//	options.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());
			//	options.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());
			//	options.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());
			//});

			// 依赖注入，将自定义的授权处理器 匹配给官方授权处理器接口，这样当系统处理授权的时候，就会直接访问我们自定义的授权处理器了。
			//services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
			// 将授权必要类注入生命周期内
			services.AddSingleton(permissionRequirement);
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
			app.UseAuthentication();
			//	app.UseMiddleware<TokenAuth>();
			//	app.UseAuthentication();
			app.UseMvc();
			//启用中间件服务生成Swagger作为JSON终结点
			app.UseSwagger();
			//启用中间件服务对swagger-ui，指定Swagger JSON终结点
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("../swagger/v1/swagger.json", "HeyTom  API");
			});
		}
	}
}
