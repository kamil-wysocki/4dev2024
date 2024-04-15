using _4dev2024.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace _4dev2024.Shared.Abstractions.Controllers
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class GenericControllerAttribute : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.BaseType?.GetGenericTypeDefinition() == typeof(BaseController<>))
            {
                if (typeof(IModule).IsAssignableFrom(controller.ControllerType.BaseType?.GetGenericArguments()[0]))
                {
                    IModule? module = Activator.CreateInstance(controller.ControllerType.BaseType.GetGenericArguments()[0]) as IModule;

                    if (module != null)
                    {
                        controller.ControllerName = $"{module.Path}/{controller.ControllerName}".ToLower();
                    }
                }
            }
        }
    }
}
