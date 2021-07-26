using Microsoft.AspNetCore.Mvc;
using RestaurantOrderWebApi.Domain.Dtos.Request;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Services;

namespace RestaurantOrderWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService _orderService)
        {
            this._orderService = _orderService;
        }

        [HttpPost]
        public string CreatOrder(OrderRequestDto orderRequestDto)
        {
            var orderResponseDto = _orderService.CreateOrder(orderRequestDto);

            return orderResponseDto;
        }
    }
}
