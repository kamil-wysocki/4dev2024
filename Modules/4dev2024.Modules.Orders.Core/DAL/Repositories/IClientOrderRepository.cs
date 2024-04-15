using _4dev2024.Modules.Invoices.Core.Entities;
using _4dev2024.Shared.Abstractions.Databases;

namespace _4dev2024.Modules.Invoices.Core.DAL.Repositories
{
    internal interface IClientOrderRepository : IRepository<ClientOrder, Guid>
    {
        Task<IReadOnlyList<ClientOrder>> GetByClientId(Guid clientId);
    }
}
