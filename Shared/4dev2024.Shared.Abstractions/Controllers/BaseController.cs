using _4dev2024.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Mvc;

namespace _4dev2024.Shared.Abstractions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [GenericController]
    public abstract class BaseController<TModule> : ControllerBase where TModule : class, IModule;
}