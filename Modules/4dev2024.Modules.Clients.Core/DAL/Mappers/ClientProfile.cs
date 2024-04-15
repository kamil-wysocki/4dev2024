using _4dev2024.Modules.Clients.Core.DTO;
using _4dev2024.Modules.Clients.Core.Entities;
using AutoMapper;

namespace _4dev2024.Modules.Clients.Core.DAL.Mappers
{
    internal class ClientProfile : Profile
    {
        public ClientProfile() => CreateMap<ClientDTO, Client>()
            .ReverseMap();
    }
}
