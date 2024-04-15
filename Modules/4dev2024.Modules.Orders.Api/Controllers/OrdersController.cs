using _4dev2024.Modules.Orders.Core.DTO;
using _4dev2024.Modules.Orders.Core.Services;
using _4dev2024.Shared.Abstractions.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4dev2024.Modules.Orders.Api.Controllers
{
    internal class OrdersController : BaseController<OrdersModule>
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("info")]
        public ActionResult<string> Get() => "4Dev2024.Orders API";


        [HttpGet("clients/{clientId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<ClientOrderDTO>> GetClientOrders(Guid clientId) => 
            await _orderService.GetClientOrdersAsync(clientId);
    }
}
