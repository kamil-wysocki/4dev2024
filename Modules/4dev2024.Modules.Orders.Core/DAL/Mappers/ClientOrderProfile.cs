using _4dev2024.Modules.Invoices.Core.DTO;
using _4dev2024.Modules.Invoices.Core.Entities;
using AutoMapper;

namespace _4dev2024.Modules.Invoices.Core.DAL.Mappers
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
