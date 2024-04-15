using _4dev2024.Shared.Abstractions.Messaging;
using System.Threading.Channels;

namespace _4dev2024.Shared.Infrastructure.Messaging.Dispatchers
{
    internal interface IMessageChannel
    {
        ChannelReader<IMessage> Reader { get; }
        ChannelWriter<IMessage> Writer { get; }
    }
}
