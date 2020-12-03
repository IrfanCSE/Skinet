using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using AutoMapper;
using API.Errors;

namespace API.Controllers
{
    [Route("api/orders")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderDto orderDto)
        {
            var email = HttpContext.User.RetriveEmailFromClaimsPrincipal();
            var address = _mapper.Map<AddressDto,Address>(orderDto.ShipToAddress);

            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId,address);

            if(order==null) return BadRequest(new ApiResponse(400,"Problem, while creating order"));

            return Ok(order);
        }
    }
}