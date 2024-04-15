using _4dev2024.Shared.Abstractions.Messaging;
using System.Threading.Channels;

namespace _4dev2024.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class MessageChannel : IMessageChannel
    {
        private readonly Channel<IMessage> _messages = Channel.CreateUnbounded<IMessage>();

        public ChannelReader<IMessage> Reader => _messages.Reader;

        public ChannelWriter<IMessage> Writer => _messages.Writer;
    }
}
