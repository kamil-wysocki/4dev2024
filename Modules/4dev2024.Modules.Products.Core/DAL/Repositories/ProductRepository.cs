using _4dev2024.Modules.Products.Core.Entities;
using _4dev2024.Shared.Abstractions.Databases;
using Microsoft.EntityFrameworkCore;

namespace _4dev2024.Modules.Products.Core.DAL.Repositories
{
    internal class ProductRepository : IRepository<Product, Guid>
    {
        private readonly ProductsDbContext _dbContext;
        private readonly DbSet<Product> _products;

        public ProductRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
            _products = _dbContext.Products;
        }

        public async Task AddAsync(Product client)
        {
            await _products.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Product? product = await _products.FindAsync(id);

            if (product != null)
            {
                _products.Remove(product);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id) => await _products.FindAsync(id);

        public async Task<IReadOnlyList<Product>> GetAsync() => await _products.ToListAsync();

        public async Task UpdateAsync(Product product)
        {
            _products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
