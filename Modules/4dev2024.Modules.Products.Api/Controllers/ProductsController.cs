using _4dev2024.Modules.Products.Core.DTO;
using _4dev2024.Modules.Products.Core.Services;
using _4dev2024.Shared.Abstractions.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4dev2024.Modules.Products.Api.Controllers
{
    internal class ProductsController : BaseController<ProductsModule>
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("info")]
        public ActionResult<string> Get() => "4Dev2024.Products API";

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<ProductDTO>> GetProducts()
            => await _productService.GetAsync();


        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ProductDTO> GetProduct(Guid id) =>
            await _productService.GetByIdAsync(id);


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task UpdateClient([FromBody] ProductDTO product) =>
            await _productService.UpdateAsync(product);
    }
}
