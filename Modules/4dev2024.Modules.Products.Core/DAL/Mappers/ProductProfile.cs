using _4dev2024.Modules.Products.Core.DTO;
using _4dev2024.Modules.Products.Core.Entities;
using AutoMapper;

namespace _4dev2024.Modules.Products.Core.DAL.Mappers
{
    internal class ProductProfile : Profile
    {
        public ProductProfile() => CreateMap<ProductDTO, Product>()
            .ReverseMap();
    }
}
