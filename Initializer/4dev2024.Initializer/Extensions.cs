using _4dev2024.Shared.Abstractions.Modules;
using _4dev2024.Shared.Infrastructure;
using System.Reflection;

namespace _4dev2024.Initializer
{
    internal static class Extensions
    {
        private static IList<Assembly> _assemblies;
        private static IList<IModule> _modules;

        private static IServiceCollection InitModules(this IServiceCollection services, IConfiguration configuration)
        {
            _assemblies = ModuleLoader.LoadAssemblies(configuration);
            _modules = ModuleLoader.LoadModules(_assemblies);

            return services;
        }

        internal static IServiceCollection RegisterModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.InitModules(configuration);
            services.AddInfrastructure(_modules, _assemblies);
            foreach (var module in _modules)
            {
                module.Register(services, configuration);
            }

            return services;
        }

        internal static void UseModules(this WebApplication app)
        {
            app.UseInfrastructure();
            foreach (var module in _modules)
            {
                module.Use(app);
            }
        }
    }
}
