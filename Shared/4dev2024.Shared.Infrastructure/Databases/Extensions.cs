using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _4dev2024.Shared.Infrastructure.Databases
{
    public static class Extensions
    {
        public static IServiceCollection AddDbContext<T>(this IServiceCollection services, 
            string connectionString) where T : DbContext
        {
            services.AddDbContext<T>(x => x.UseSqlServer(connectionString));

            return services;
        }
    }
}
