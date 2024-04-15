using _4dev2024.Modules.Clients.Core.DTO;
using _4dev2024.Modules.Clients.Core.Entities;
using _4dev2024.Modules.Clients.Core.Events;
using _4dev2024.Shared.Abstractions.Databases;
using _4dev2024.Shared.Abstractions.Messaging;
using AutoMapper;

namespace _4dev2024.Modules.Clients.Core.Services
{
    internal class ClientService : IClientService
    {
        private readonly IRepository<Client,Guid> _clientRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBroker _messageBroker;

        public ClientService(IRepository<Client, Guid> clientRepository, IMapper mapper, 
            IMessageBroker messageBroker)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _messageBroker = messageBroker;
        }

        public async Task AddAsync(ClientDTO clientDTO)
        {
            await _clientRepository.AddAsync(_mapper.Map<Client>(clientDTO));

            var client = await _clientRepository.GetByIdAsync(clientDTO.Id);

            if (client != null)
            {
                var clientCreatedEvent = new ClientCreated(client.Id, client.FirstName, 
                    client.LastName, client.Phone, client.Address);
                await _messageBroker.PublishAsync(clientCreatedEvent);
            }
        }

        public async Task DeleteAsync(Guid Id) => 
            await _clientRepository.DeleteAsync(Id);

        public async Task<IReadOnlyList<ClientDTO>> GetAsync() => 
            _mapper.Map<IReadOnlyList<ClientDTO>>(await _clientRepository.GetAsync());

        public async Task<ClientDTO> GetByIdAsync(Guid Id) => 
            _mapper.Map<ClientDTO>(await _clientRepository.GetByIdAsync(Id));

        public async Task UpdateAsync(ClientDTO clientDTO) 
            => await _clientRepository.UpdateAsync(_mapper.Map<Client>(clientDTO));
    }
}
