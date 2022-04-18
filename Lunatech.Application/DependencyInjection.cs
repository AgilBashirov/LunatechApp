using Lunatech.Application.Services.Abstraction;
using Lunatech.Persistence.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Lunatech.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddRepos().AddServices();
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(e =>
                    e.IsClass
                    && !e.IsAbstract
                    && e.GetInterfaces().Contains(typeof(IBaseService)))
                .ToList()
                .ForEach(type =>
                {
                    var nestedInterface = type.GetInterfaces().First(x => x.GetInterfaces().Contains(typeof(IBaseService)));
                    services.AddScoped(nestedInterface, type);
                });
            return services;
        }

        private static IServiceCollection AddRepos(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(e => !e.IsAbstract
                            && e.BaseType is not null
                            && e.BaseType.IsGenericType
                            && e.BaseType.GetGenericTypeDefinition() == typeof(BaseRepo<>))
                .ToList()
                .ForEach(x => services.AddScoped(x));


            return services;
        }
    }

}
