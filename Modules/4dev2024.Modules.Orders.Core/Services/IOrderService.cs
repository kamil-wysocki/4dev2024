using _4dev2024.Modules.Orders.Core.DTO;

namespace _4dev2024.Modules.Orders.Core.Services
{
    internal interface IOrderService
    {
        Task<IReadOnlyList<OrderDTO>> GetAsync();

        Task<OrderDTO> GetByIdAsync(Guid Id);

        Task AddAsync(OrderDTO clientDTO);

        Task DeleteAsync(Guid Id);

        Task UpdateAsync(OrderDTO clientDTO);

        Task<IReadOnlyList<ClientOrderDTO>> GetClientOrdersAsync(Guid clientId);
    }
}
