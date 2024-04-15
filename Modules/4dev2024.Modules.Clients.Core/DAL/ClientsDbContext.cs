using _4dev2024.Modules.Clients.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4dev2024.Modules.Clients.Core.DAL
{
    internal class ClientsDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ClientsDbContext(DbContextOptions<ClientsDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(nameof(Clients).ToLowerInvariant());
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
