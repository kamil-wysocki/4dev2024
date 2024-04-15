using _4dev2024.Modules.Products.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4dev2024.Modules.Products.Core.DAL
{
    internal class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(nameof(Products).ToLowerInvariant());
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
