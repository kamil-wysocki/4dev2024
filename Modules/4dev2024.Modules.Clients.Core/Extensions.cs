using _4dev2024.Modules.Clients.Core.DAL;
using _4dev2024.Modules.Clients.Core.DAL.Repositories;
using _4dev2024.Modules.Clients.Core.Entities;
using _4dev2024.Modules.Clients.Core.Services;
using _4dev2024.Shared.Abstractions.Databases;
using _4dev2024.Shared.Infrastructure.Databases;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("4dev2024.Modules.Clients.Api")]
namespace _4dev2024.Modules.Clients.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ClientsDbContext>(connectionString);

            services.AddScoped<IRepository<Client, Guid>, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}
