using AutoMapper;
using ItemBoxStore.Infrastructure.MapProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure
{
    public static class ComponentRegistrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.ConfigureAutomapper();
        }

        private static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            return services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            config.AssertConfigurationIsValid();
            return config;
        }
    }
}
