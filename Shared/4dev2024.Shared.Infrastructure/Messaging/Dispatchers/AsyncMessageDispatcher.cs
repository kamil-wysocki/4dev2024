
using _4dev2024.Shared.Abstractions.Messaging;

namespace _4dev2024.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class AsyncMessageDispatcher : IAsyncMessageDispatcher
    {
        private readonly IMessageChannel _channel;

        public AsyncMessageDispatcher(IMessageChannel channel) => _channel = channel;

        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage => 
            await _channel.Writer.WriteAsync(message);
    }
}
