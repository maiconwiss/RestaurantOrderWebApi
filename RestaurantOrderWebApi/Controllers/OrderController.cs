using Microsoft.AspNetCore.Mvc;
using RestaurantOrderWebApi.Domain.Dtos.Request;
using RestaurantOrderWebApi.Domain.Dtos.Response;
using RestaurantOrderWebApi.Domain.Interfaces.Services;

namespace RestaurantOrderWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService _orderService)
        {
            this._orderService = _orderService;
        }

        [HttpPost]
        public OrderResponseDto CreatOrder(OrderRequestDto orderRequestDto)
        {
            var orderResponseDto = _orderService.CreateOrder(orderRequestDto);

            return orderResponseDto;
        }
    }
}
