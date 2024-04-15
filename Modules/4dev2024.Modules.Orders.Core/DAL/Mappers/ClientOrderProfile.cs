using _4dev2024.Modules.Orders.Core.DTO;
using _4dev2024.Modules.Orders.Core.Entities;
using AutoMapper;

namespace _4dev2024.Modules.Orders.Core.DAL.Mappers
{
    internal class ClientOrderProfile : Profile
    {
        public ClientOrderProfile()
        {
            CreateMap<ClientOrderDTO, ClientOrder>()
                .ReverseMap();
        }
    }
}
