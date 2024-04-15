using _4dev2024.Shared.Abstractions.Modules;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _4dev2024.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class BackgroundDispatcher : BackgroundService
    {
        private readonly IMessageChannel _channel;
        private readonly ILogger<BackgroundDispatcher> _logger;
        private readonly IModuleClient _client;

        public BackgroundDispatcher(ILogger<BackgroundDispatcher> logger, IMessageChannel channel, 
            IModuleClient client)
        {
            _logger = logger;
            _channel = channel;
            _client = client;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Start the background dispatcher...");

            await foreach (var message in _channel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _client.PublishAsync(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
            }

            _logger.LogInformation("Finished running the backgroud dispatcher...");
        }
    }
}
