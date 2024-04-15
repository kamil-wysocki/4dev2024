using _4dev2024.Shared.Abstractions.Modules;
using System.Reflection;

namespace _4dev2024.Initializer
{
    internal static class ModuleLoader
    {
        public static IList<Assembly> LoadAssemblies(IConfiguration configuration)
        {
            string? modulePath = configuration.GetValue<string>("ModuleAssemblyPath");

            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            string[] locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();

            List<string> files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase)).ToList();

            List<string> disabledModules = new List<string>();

            foreach (var file in files)
            {
                if (!file.Contains(modulePath))
                    continue;

                string moduleName = file.Split(modulePath)[1].Split(".")[0].ToLowerInvariant();
                bool enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");

                if (!enabled)
                    disabledModules.Add(file);
            }

            foreach (var module in disabledModules)
            {
                files.Remove(module);
            }

            files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

            return assemblies;
        }

        public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies) 
            => assemblies.SelectMany(x => x.GetTypes())
                         .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
                         .OrderBy(x => x.Name)
                         .Select(Activator.CreateInstance)
                         .Cast<IModule>()
                         .ToList();
                
            
    }
}
