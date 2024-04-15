using _4dev2024.Modules.Orders.Core.Entities;
using _4dev2024.Shared.Abstractions.Databases;

namespace _4dev2024.Modules.Orders.Core.DAL.Repositories
{
    internal class OrderRepository : IRepository<Order, Guid>
    {
        public Task AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
