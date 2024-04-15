using _4dev2024.Modules.Clients.Core.DTO;
using _4dev2024.Modules.Clients.Core.Services;
using _4dev2024.Shared.Abstractions.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4dev2024.Modules.Clients.Api.Controllers
{
    internal class ClientsController : BaseController<ClientsModule>
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientsService)
        {
            _clientService = clientsService;
        }

        [HttpGet("info")]
        public ActionResult<string> Get() => "4Dev2024.Clients API";


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<ClientDTO>> GetClients()
            => await _clientService.GetAsync();


        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ClientDTO> GetClient(Guid id) =>
            await _clientService.GetByIdAsync(id);


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateClient([FromBody] ClientDTO client)
        {
            await _clientService.AddAsync(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task UpdateClient([FromBody] ClientDTO client) =>
            await _clientService.UpdateAsync(client);

    }
}
