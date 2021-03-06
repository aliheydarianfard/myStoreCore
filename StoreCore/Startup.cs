using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.AuthenticateHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.UnitOfWork;

namespace StoreCore
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
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddControllers();
			services.Configure<IISServerOptions>(options =>
			{
				options.AllowSynchronousIO = true;
			});


			services.AddScoped<IJWTHandler, JWTHandler>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddSwaggerGen();
			services.AddAuthentication("Bearer")
			.AddJwtBearer("Bearer", options =>
			{
				options.Authority = "https://localhost:44356";
				options.RequireHttpsMetadata = false;

				options.Audience = "sitecore.profile.api";
			});
		}





		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = string.Empty;
			});
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}

}
