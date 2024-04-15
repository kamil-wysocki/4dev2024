using _4dev2024.Modules.Products.Core.DTO;

namespace _4dev2024.Modules.Products.Core.Services
{
    internal interface IProductService
    {
        Task<IReadOnlyList<ProductDTO>> GetAsync();

        Task<ProductDTO> GetByIdAsync(Guid Id);

        Task AddAsync(ProductDTO clientDTO);

        Task DeleteAsync(Guid Id);

        Task UpdateAsync(ProductDTO clientDTO);
    }
}
