using AutoMapper;
using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Contexts.Item.Services.Implementations;
using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Infrastructure.DataAccess.Repositories.Items;
using ItemBoxStore.Infrastructure.DataAccess.Repositories;
using ItemBoxStore.Infrastructure.MapProfiles;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemBoxStore.Infrastructure.PasswordHasher;

namespace ItemBoxStore.Infrastructure
{
    public static class ComponentRegistrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.ConfigureServices();
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IStorageFileService, StorageFileService>();
            services.AddTransient<IItemService, ItemService>();

            services.AddScoped<IPasswordHasher, ItemBoxStore.Infrastructure.PasswordHasher.PasswordHasher>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStorageFileRepository, StorageFileRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<DbContext>(s => s.GetRequiredService<ApplicationDbContext>());

            services.AddTransient<IItemService, ItemService>();
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<ItemProfile>();
                cfg.AddProfile<StorageFileProfile>();
            });
            config.AssertConfigurationIsValid();
            return config;
        }
    }
}
