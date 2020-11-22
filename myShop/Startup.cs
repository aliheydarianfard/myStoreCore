using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahf.Data;
using Ahf.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace myShop
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

			services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
			services.AddScoped<IApplcationDbContext, SqlServerApplicationContext>();

			services.AddDbContext<IApplcationDbContext, SqlServerApplicationContext>(
				(Options) =>
			{
				Options.UseSqlServer("Data Source=;Initial Catalog=MyStoreDB;Integrated Security=true;");
			}, optionsLifetime: ServiceLifetime.Scoped);

			IMvcBuilder configController = services.AddControllers();
			services.AddControllers();
			services.AddSwaggerGen();
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(
					builder => builder
						//.AllowAnyOrigin()
						.WithOrigins("http://localhost:4500", "http://localhost:5001", "http://localhost:4200")
						.AllowAnyMethod()
						.WithMethods("POST", "DELETE", "PUT", "GET", "OPTIONS")
						.AllowAnyHeader()
						.AllowCredentials()
						);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = string.Empty;
			});
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			app.UseCors();
		}
	}
}
