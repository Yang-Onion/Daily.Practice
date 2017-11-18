using Autofac;
using DynamicalServices;
using DynamicalServices.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DynamicalDependencyInjection
{
    public static class ServiceDIExtension
    {

        public static ContainerBuilder AddSingletonServices(this ContainerBuilder builder)
        {
            Type singletonType = typeof(ISingleton);
            Assembly assembly = Assembly.Load("DynamicalServices");
            var allTypes = assembly.GetTypes();
            var singletonInterfaces = allTypes.Where(g => singletonType.IsAssignableFrom(g) && g != singletonType && g.IsInterface);
            var singletonServices = allTypes.Where(g => singletonType.IsAssignableFrom(g) && g.IsClass && !g.IsAbstract);
            foreach (Type serviceType in singletonInterfaces)
            {
                if (serviceType == null)
                    throw new Exception("");

                Type implementType = singletonServices.Where(t => t.IsInstanceOfType(serviceType)).FirstOrDefault();

                if (implementType == null)
                   throw new Exception("");

                //services.AddSingleton<serviceType, implementType>();
                //builder.RegisterType<implementType>().As<serviceType>();

                //builder.RegisterType<implementType>().As<serviceType>();
            }

            return builder;
        }

        public static IServiceCollection AddTransientServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddScopeServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
