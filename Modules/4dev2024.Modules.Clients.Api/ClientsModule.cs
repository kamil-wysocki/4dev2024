using _4dev2024.Modules.Clients.Core;
using _4dev2024.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _4dev2024.Modules.Clients.Api
{
    public class ClientsModule : IModule
    {
        public string Name => "Clients";

        public string Path => "clients-module";

        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCore(configuration.GetConnectionString(Name));
        }

        public void Use(WebApplication app)
        {
        }
    }
}
