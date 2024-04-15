using _4dev2024.Modules.Orders.Core.DAL;
using _4dev2024.Modules.Orders.Core.DAL.Repositories;
using _4dev2024.Modules.Orders.Core.Entities;
using _4dev2024.Modules.Orders.Core.Services;
using _4dev2024.Shared.Abstractions.Databases;
using _4dev2024.Shared.Infrastructure.Databases;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("4dev2024.Modules.Orders.Api")]
namespace _4dev2024.Modules.Orders.Core
{
    internal static class Extensions
    {
        internal static IServiceCollection AddCore(this IServiceCollection services, 
            string connectionString)
        {
            services.AddDbContext<OrdersDbContext>(connectionString);
            services.AddScoped<IRepository<Order, Guid>, OrderRepository>();
            services.AddScoped<IClientOrderRepository, ClientOrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
