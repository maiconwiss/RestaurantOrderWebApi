using RestaurantOrderWebApi.Domain.Dtos.Request;
using RestaurantOrderWebApi.Domain.Dtos.Response;

namespace RestaurantOrderWebApi.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        OrderResponseDto CreateOrder(OrderRequestDto orderRequestDto);
    }
}
