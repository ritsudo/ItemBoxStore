using ItemBoxStore.Application.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTests
{
    public class WebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => 
            {
                services.AddScoped<IItemRepository, ItemRepositoryStub>();
                services.AddScoped<IUserRepository, UserRepositoryStub>();
            });

            base.ConfigureWebHost(builder);
        }
    }
}
