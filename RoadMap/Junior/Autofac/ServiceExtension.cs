using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Junior.Autofac
{
	public static class ServiceExtension
	{
		public static ContainerBuilder ConfigAutoFac(this IServiceCollection services)
		{
			var containerBuilder = new ContainerBuilder();
			containerBuilder.Populate(services);
			containerBuilder.RegisterAssemblyTypes(Assembly.Load("Repository"))
				.Where(x => x.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			containerBuilder.RegisterAssemblyTypes(Assembly.Load("Service"))
				.Where(x => x.Name.EndsWith("Service"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();

			containerBuilder.RegisterType<DbContext>().AsSelf();
			return containerBuilder;
		}
	}
}
