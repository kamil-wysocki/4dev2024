using _4dev2024.Shared.Abstractions.Messaging;
using _4dev2024.Shared.Abstractions.Modules;
using _4dev2024.Shared.Infrastructure.Messaging.Dispatchers;

namespace _4dev2024.Shared.Infrastructure.Messaging.Brokers
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IModuleClient _client;
        private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
        private readonly MessagingOptions _messagingOptions;

        public MessageBroker(IModuleClient client, IAsyncMessageDispatcher asyncMessageDispatcher, 
            MessagingOptions messagingOptions)
        {
            _client = client;
            _asyncMessageDispatcher = asyncMessageDispatcher;
            _messagingOptions = messagingOptions;
        }

        public async Task PublishAsync(params IMessage[] messages)
        {
            if (messages is null)
                return;

            messages = messages.Where(x => x is not null).ToArray();

            if (!messages.Any())
                return;

            IList<Task> tasks = new List<Task>();

            foreach (IMessage message in messages)
            {
                if (_messagingOptions.UseBackgroundDispatcher)
                { 
                    await _asyncMessageDispatcher.PublishAsync(message);
                    continue;
                }
                tasks.Add(_client.PublishAsync(message));
            }

            await Task.WhenAll(tasks);
        }
    }
}
