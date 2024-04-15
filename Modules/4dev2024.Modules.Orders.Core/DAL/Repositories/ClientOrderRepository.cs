using _4dev2024.Modules.Orders.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4dev2024.Modules.Orders.Core.DAL.Repositories
{
    internal class ClientOrderRepository : IClientOrderRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        private readonly DbSet<ClientOrder> _clientOrders;

        public ClientOrderRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
            _clientOrders = ordersDbContext.ClientOrders;
        }

        public async Task AddAsync(ClientOrder entity)
        {
            await _clientOrders.AddAsync(entity);
            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            ClientOrder? clientOrder = await _clientOrders.FindAsync(id);

            if (clientOrder != null)
            {
                _clientOrders.Remove(clientOrder);
            }
            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ClientOrder>> GetAsync() 
            => await _clientOrders.ToListAsync();

        public async Task<IReadOnlyList<ClientOrder>> GetByClientId(Guid clientId) => 
            await _clientOrders.Where(p => p.ClientId == clientId).ToListAsync();

        public async Task<ClientOrder?> GetByIdAsync(Guid id)
            => await _clientOrders.FindAsync(id);

        public async Task UpdateAsync(ClientOrder entity)
        {
            _clientOrders.Update(entity);
            await _ordersDbContext.SaveChangesAsync();
        }
    }
}
