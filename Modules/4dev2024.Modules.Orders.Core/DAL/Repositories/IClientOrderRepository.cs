using _4dev2024.Modules.Orders.Core.Entities;
using _4dev2024.Shared.Abstractions.Databases;

namespace _4dev2024.Modules.Orders.Core.DAL.Repositories
{
    internal interface IClientOrderRepository : IRepository<ClientOrder, Guid>
    {
        Task<IReadOnlyList<ClientOrder>> GetByClientId(Guid clientId);
    }
}
