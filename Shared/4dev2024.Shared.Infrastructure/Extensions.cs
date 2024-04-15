using _4dev2024.Shared.Abstractions.Modules;
using _4dev2024.Shared.Infrastructure.Api;
using _4dev2024.Shared.Infrastructure.Events;
using _4dev2024.Shared.Infrastructure.Messaging;
using _4dev2024.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("4dev2024.Initializer")]
namespace _4dev2024.Shared.Infrastructure
{
    internal static class Extensions
    {
        private const string CorsPolicy = "cors";

        internal static IServiceCollection AddInfrastructure(this IServiceCollection services, 
                                                             IList<IModule> modules, 
                                                             IList<Assembly> assemblies)
        {
            services.AddCors(cors =>
            {
                cors.AddPolicy(CorsPolicy, policy =>
                {
                    policy.WithOrigins("*")
                          .WithMethods("POST", "PUT", "DELETE", "GET")
                          .WithHeaders("Content-Type", "Authorization");
                });
            });

            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    var removedParts = new List<ApplicationPart>();

                    foreach (var disabledModule in services.GetDisabledModules())
                    {
                        var parts = manager.ApplicationParts
                                           .Where(x => x.Name.Contains(disabledModule, StringComparison.InvariantCultureIgnoreCase));

                        removedParts.AddRange(parts);
                    }

                    removedParts.ForEach(part => manager.ApplicationParts.Remove(part));

                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            services.AddOpenApi();

            services.AddAutoMapper(assemblies);

            services.AddModuleInfo(modules);

            services.AddEvents(assemblies);

            services.AddModuleRequests(assemblies);

            services.AddMessaging();

            return services;
        }

        private static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(swagger =>
            {
                swagger.CustomSchemaIds(x => x.FullName);
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "4Dev2024 API",
                    Version = "v1",
                });
            });

            return services;
        }

        private static IList<string> GetDisabledModules(this IServiceCollection services)
        {
            List<string> disabledModules = new List<string>();

            using var serviceProvider = services.BuildServiceProvider();
            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                if (!key.Contains(":module:enabled"))
                    continue;

                if(!bool.Parse(value))
                    disabledModules.Add(key.Split(":")[0]);
            }
            return disabledModules;
        }

        internal static IApplicationBuilder UseInfrastructure(this WebApplication app)
        {
            app.UseCors(CorsPolicy);

            app.UseOpenApi();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/", () => "Hello World 4Dev 2024!");

            app.MapControllers();

            app.MapModuleInfo();

            return app;
        }

        private static void UseOpenApi(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
