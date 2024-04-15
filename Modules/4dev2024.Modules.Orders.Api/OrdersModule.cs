using _4dev2024.Modules.Orders.Core;
using _4dev2024.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _4dev2024.Modules.Orders.Api
{
    internal class OrdersModule : IModule
    {
        public string Name => "Orders";

        public string Path => "orders-module";

        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCore(configuration.GetConnectionString(Name));
        }

        public void Use(WebApplication app)
        {

        }
    }
}
