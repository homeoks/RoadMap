using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Junior.AppConstant;
using Junior.AppConstant.Configuration;
using Junior.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Junior.Mapper
{
	public static class MapperServiceExtension
	{
		public static IServiceCollection ConfigMapper(this IServiceCollection services)
		{
			var type = typeof(IMapperProfile);
			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p));

			var allProfile = types.Select(x => x.GetTypeInfo());

			services.AddAutoMapper(allProfile.ToArray());
			return services;
		}
	}
}
