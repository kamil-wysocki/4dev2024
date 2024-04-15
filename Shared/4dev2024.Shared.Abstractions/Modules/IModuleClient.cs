namespace _4dev2024.Shared.Abstractions.Modules
{
    public interface IModuleClient
    {
        Task PublishAsync(object message);
    }
}
