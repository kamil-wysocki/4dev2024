using _4dev2024.Shared.Abstractions.Messaging;
using _4dev2024.Shared.Infrastructure.Messaging.Brokers;
using _4dev2024.Shared.Infrastructure.Messaging.Dispatchers;
using _4dev2024.Shared.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;

namespace _4dev2024.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        private static readonly string SectionName = "messaging";

        internal static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, MessageBroker>();
            services.AddSingleton<IMessageChannel, MessageChannel>();
            services.AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>();

            services.AddOptions<MessagingOptions>(SectionName);

            var options = services.GetOptions<MessagingOptions>(SectionName);
            services.AddSingleton(options);

            if (options.UseBackgroundDispatcher)
            {
                services.AddHostedService<BackgroundDispatcher>();
            }

            return services;
        }
    }
}
