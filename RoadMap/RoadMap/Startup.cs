using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Junior.AppConstant;
using Junior.AppConstant.Configuration;
using Junior.Autofac;
using Junior.Extension;
using Junior.Mapper;
using Junior.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.ApplicationDbContext;
using Repository.Implement;
using Service.Interface;
using Service.Implement;
using Repository.Interface;
using Repository.MongoDb;
using Service.Profile;
using Swashbuckle.AspNetCore.Swagger;
using BookstoreDatabaseSettings = Junior.AppConstant.Configuration.BookstoreDatabaseSettings;

namespace RoadMap
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public IContainer ApplicationContainer { get; private set; }
		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.InitConfiguration(Configuration);

			services.ConfigCors(AppSetting.Cors.AllowAll);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			var connectionString = AppConfiguration.ConnectionStrings.DefaultConnection;
			services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(connectionString));

			services.ConfigMapper();
			services.ConfigAuthentication();
			services.ConfigSwagger();

			var container = services.ConfigAutoFac();
			this.ApplicationContainer = container.Build();
			return new AutofacServiceProvider(ApplicationContainer);
		}
		
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseCors(AppSetting.Cors.AllowAll);
			app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meo's RoadMap");
				})
				.UseSwagger();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseAuthentication();
			app.UseMiddleware(typeof(AppMiddleware));
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
