using _4dev2024.Modules.Orders.Core.DAL.Repositories;
using _4dev2024.Modules.Orders.Core.DTO;
using _4dev2024.Modules.Orders.Core.Entities;
using _4dev2024.Shared.Abstractions.Databases;
using AutoMapper;

namespace _4dev2024.Modules.Orders.Core.Services
{
    internal class OrderService : IOrderService
    {
        private IRepository<Order, Guid> _orderRepository;
        private IClientOrderRepository _clientOrderRepository;
        private IMapper _mapper;

        public OrderService(IRepository<Order, Guid> orderRepository,
            IClientOrderRepository clientOrderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _clientOrderRepository = clientOrderRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderDTO orderDTO) => 
            await _orderRepository.AddAsync(_mapper.Map<Order>(orderDTO));

        public async Task DeleteAsync(Guid id) => 
            await _orderRepository.DeleteAsync(id);

        public async Task<IReadOnlyList<OrderDTO>> GetAsync() => 
            _mapper.Map<IReadOnlyList<OrderDTO>>(await _orderRepository.GetAsync());

        public async Task<OrderDTO> GetByIdAsync(Guid Id) => 
            _mapper.Map<OrderDTO>(await _orderRepository.GetByIdAsync(Id));

        public async Task<IReadOnlyList<ClientOrderDTO>> GetClientOrdersAsync(Guid clientId)
        {
            var clientOrders = await _clientOrderRepository.GetByClientId(clientId);

            return _mapper.Map<IReadOnlyList<ClientOrderDTO>>(clientOrders);
        }

        public async Task UpdateAsync(OrderDTO clientDTO)
        {
            await _clientOrderRepository.UpdateAsync(_mapper.Map<ClientOrder>(clientDTO));
        }
    }
}
