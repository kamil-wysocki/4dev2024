using _4dev2024.Shared.Abstractions.Events;
using _4dev2024.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("4dev2024.Initializer")]
namespace _4dev2024.Shared.Infrastructure.Modules
{
    internal static class Extensions
    {
        internal static IServiceCollection AddModuleInfo(this IServiceCollection services, IList<IModule> modules)
        {
            ModuleInfoProvider provider = new ModuleInfoProvider();
            var moduleInfo = modules.Select(x => new ModuleInfo(x.Name, x.Path));
            provider.Modules.AddRange(moduleInfo);
            services.AddSingleton(provider);
            return services;
        }

        internal static void MapModuleInfo(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet("modules", context =>
            {
                var moduleInfoProvider = context.RequestServices.GetRequiredService<ModuleInfoProvider>();

                return context.Response.WriteAsJsonAsync(moduleInfoProvider.Modules);
            });
        }

        internal static WebApplicationBuilder ConfigureModules(this WebApplicationBuilder builder)
        {
            foreach (string settingPath in GetSettings(builder.Environment.ContentRootPath, "*"))
            {
                builder.Configuration.AddJsonFile(settingPath);
            }

            foreach (string settingPath in GetSettings(builder.Environment.ContentRootPath, 
                $"*.{builder.Environment.EnvironmentName}"))
            {
                builder.Configuration.AddJsonFile(settingPath);
            }

            return builder;
        }

        private static IEnumerable<string> GetSettings(string path, string pattern)
            => Directory.EnumerateFiles(path, $"module.{pattern}.json", SearchOption.AllDirectories);

        internal static IServiceCollection AddModuleRequests(this IServiceCollection services,
            IList<Assembly> assemblies)
        {
            services.AddModuleRegistry(assemblies);
            services.AddSingleton<IModuleClient, ModuleClient>();
            services.AddSingleton<IModuleSerializer, JsonModuleSerializer>();

            return services;
        }

        private static IServiceCollection AddModuleRegistry(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            ModuleRegistry registry = new ModuleRegistry();
            
            var types = assemblies.SelectMany(x => x.GetTypes()).ToArray();

            var eventTypes = types
                .Where(x => x.IsClass && typeof(IEvent).IsAssignableFrom(x))
                .ToArray();

            services.AddSingleton<IModuleRegistry>(sp =>
            {
                var eventDispatcher = sp.GetRequiredService<IEventDispatcher>();
                var eventDispatcherType = eventDispatcher.GetType();

                foreach (var type in eventTypes)
                {
                    registry.AddBroadcastAction(type, @event =>
                        (Task)eventDispatcherType.GetMethod(nameof(eventDispatcher.PublishAsync))
                            ?.MakeGenericMethod(type)
                            .Invoke(eventDispatcher, new[] { @event }));
                }

                return registry;
            });

            return services;
        }
    }
}
