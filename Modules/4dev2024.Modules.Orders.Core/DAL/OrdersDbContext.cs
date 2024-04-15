using _4dev2024.Modules.Invoices.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4dev2024.Modules.Invoices.Core.DAL
{
    internal class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<ClientOrder> ClientOrders { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(nameof(Orders).ToLowerInvariant());
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
