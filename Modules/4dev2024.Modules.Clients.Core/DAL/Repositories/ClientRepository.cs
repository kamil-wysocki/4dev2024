using _4dev2024.Modules.Clients.Core.Entities;
using _4dev2024.Shared.Abstractions.Databases;
using Microsoft.EntityFrameworkCore;

namespace _4dev2024.Modules.Clients.Core.DAL.Repositories
{
    internal class ClientRepository : IRepository<Client, Guid>
    {
        private readonly ClientsDbContext _dbContext;
        private readonly DbSet<Client> _clients;

        public ClientRepository(ClientsDbContext dbContext)
        {
            _dbContext = dbContext;
            _clients = _dbContext.Clients;
        }

        public async Task AddAsync(Client client)
        {
            await _clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Client? client = await _clients.FindAsync(id);

            if (client != null)
            {
                _clients.Remove(client);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid id) => await _clients.FindAsync(id);

        public async Task<IReadOnlyList<Client>> GetAsync() => await _clients.ToListAsync();

        public async Task UpdateAsync(Client client)
        {
            _clients.Update(client);
            await _dbContext.SaveChangesAsync();
        }
    }
}
