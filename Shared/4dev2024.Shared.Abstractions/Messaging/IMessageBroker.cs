namespace _4dev2024.Shared.Abstractions.Messaging
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IMessage[] messages);
    }
}
