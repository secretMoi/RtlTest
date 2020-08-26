using System;
using AutoMapper;
using MicroService.Data;
using MicroService.Data.Tests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace MicroService
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
			// initialise le service de connexion à la bdd
			services.AddDbContext<RtlContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(
				Configuration.GetConnectionString("TheNewRTLConnection")
			));

			services.AddControllers().AddNewtonsoftJson(s =>
				s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
			);

			// initialise l'auto mapper
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// ajoute une instance d'objet par client
			services.AddScoped<ITestRepo, TestRepo>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
