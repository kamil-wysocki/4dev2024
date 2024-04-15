using _4dev2024.Modules.Products.Core.DAL;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using _4dev2024.Shared.Abstractions.Databases;
using _4dev2024.Shared.Infrastructure.Databases;
using _4dev2024.Modules.Products.Core.Entities;
using _4dev2024.Modules.Products.Core.DAL.Repositories;
using _4dev2024.Modules.Products.Core.Services;

[assembly: InternalsVisibleTo("4dev2024.Modules.Products.Api")]
namespace _4dev2024.Modules.Products.Core
{
    internal static class Extensions
    {
        internal static IServiceCollection AddCore(this IServiceCollection services, 
            string connectionString)
        {
            services.AddDbContext<ProductsDbContext>(connectionString);
            services.AddScoped<IRepository<Product, Guid>, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
