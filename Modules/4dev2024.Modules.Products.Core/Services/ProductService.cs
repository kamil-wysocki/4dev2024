using _4dev2024.Modules.Products.Core.DTO;
using _4dev2024.Modules.Products.Core.Entities;
using _4dev2024.Shared.Abstractions.Databases;
using AutoMapper;

namespace _4dev2024.Modules.Products.Core.Services
{
    internal class ProductService : IProductService
    {
        private readonly IRepository<Product,Guid> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product, Guid> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDTO productDTO) => 
            await _productRepository.AddAsync(_mapper.Map<Product>(productDTO));

        public async Task DeleteAsync(Guid id) => await _productRepository.DeleteAsync(id);

        public async Task<IReadOnlyList<ProductDTO>> GetAsync() 
            => _mapper.Map<IReadOnlyList<ProductDTO>>(await _productRepository.GetAsync());

        public async Task<ProductDTO> GetByIdAsync(Guid id) => 
            _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));

        public async Task UpdateAsync(ProductDTO productDTO) => 
            await _productRepository.UpdateAsync(_mapper.Map<Product>(productDTO));
    }
}
