﻿using _4dev2024.Modules.Invoices.Core.DTO;

namespace _4dev2024.Modules.Invoices.Core.Services
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
