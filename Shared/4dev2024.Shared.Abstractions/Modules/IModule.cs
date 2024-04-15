using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace _4dev2024.Shared.Abstractions.Modules
{
    public interface IModule
    {
        string Name { get; }

        string Path { get; }

        void Register(IServiceCollection services, IConfiguration configuration);

        void Use(WebApplication app);
    }
}
