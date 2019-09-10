using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Junior.AppConstant;
using Junior.AppConstant.Configuration;
using Junior.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace Junior.Extension
{
	public static class ServiceExtension
	{
		public static IServiceCollection ConfigCors(this IServiceCollection services, string cors,string[] domain=null)
		{
			if(cors == AppSetting.Cors.AllowAll || domain==null)
				services.AddCors(o => o.AddPolicy(AppSetting.Cors.AllowAll, builder =>
				{
					builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						;
				}));
			else
			{
				services.AddCors(o => o.AddPolicy(AppSetting.Cors.Restrict, builder =>
				{
					builder.WithMethods(domain)
						.WithHeaders(domain)
						.WithOrigins(domain)
						;
				}));
			}
			return services;
		}
		public static IServiceCollection ConfigAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options => 
					options.TokenValidationParameters= JwtHelper.DefaultOptions().TokenValidationParameters);

			return services;
		}
		public static IServiceCollection ConfigSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new Info { Title = "Meo's RoadMap follow https://i.redd.it/t66wwptroof21.png", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "Header", Description = "Insert 'Bearer' before your token", Name = "Authorization", Type = "apiKey" });
				c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
					{ "Bearer", Enumerable.Empty<string>() },
				});

			});

			return services;
		}
		public static IServiceCollection InitConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			AppConfiguration.ConnectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
			AppConfiguration.BookstoreDatabaseSettings = configuration.GetSection("BookstoreDatabaseSettings").Get<BookstoreDatabaseSettings>();
			AppConfiguration.AuthenticationConfig = configuration.GetSection("AuthenticationConfig").Get<AuthenticationConfig>();
			return services;
		}
	}
}
