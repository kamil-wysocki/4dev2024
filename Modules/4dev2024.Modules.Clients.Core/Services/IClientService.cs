using _4dev2024.Modules.Clients.Core.DTO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("4dev2024.Modules.Clients.Api")]
namespace _4dev2024.Modules.Clients.Core.Services
{
    internal interface IClientService
    {
        Task<IReadOnlyList<ClientDTO>> GetAsync();

        Task<ClientDTO> GetByIdAsync(Guid Id);

        Task AddAsync(ClientDTO clientDTO);

        Task DeleteAsync(Guid Id);

        Task UpdateAsync(ClientDTO clientDTO);
    }
}
