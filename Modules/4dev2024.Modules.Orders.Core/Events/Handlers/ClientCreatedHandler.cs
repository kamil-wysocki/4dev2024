using _4dev2024.Modules.Invoices.Core.DAL.Repositories;
using _4dev2024.Modules.Invoices.Core.Entities;
using _4dev2024.Modules.Orders.Core.Events;
using _4dev2024.Shared.Abstractions.Events;
using Microsoft.Extensions.Logging;

namespace _4dev2024.Modules.Invoices.Core.Events.Handlers
{
    internal sealed class ClientCreatedHandler : IEventHandler<ClientCreated>
    {
        private readonly IClientOrderRepository _repository;
        private readonly ILogger<ClientCreatedHandler> _logger;

        public ClientCreatedHandler(IClientOrderRepository repository, 
            ILogger<ClientCreatedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task HandleAsync(ClientCreated @event)
        {
            await Task.Delay(10_000);
            var clientOrder = new ClientOrder()
            {
                Address = @event.Address,
                FirstName = @event.FirstName,
                ClientId = @event.Id,
                LastName = @event.LastName,
                Phone = @event.Phone,
            };

            await _repository.AddAsync(clientOrder);

            _logger.LogInformation($"Added a client with ID: '{@event.Id}'.");

        }
    }
}
