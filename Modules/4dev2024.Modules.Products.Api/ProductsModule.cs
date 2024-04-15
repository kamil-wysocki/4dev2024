using _4dev2024.Modules.Products.Core;
using _4dev2024.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _4dev2024.Modules.Products.Api
{
    internal class ProductsModule : IModule
    {
        public string Name => "Products";

        public string Path => "products-module";

        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCore(configuration.GetConnectionString(nameof(Name)));
        }

        public void Use(WebApplication app)
        {
        }
    }
}
