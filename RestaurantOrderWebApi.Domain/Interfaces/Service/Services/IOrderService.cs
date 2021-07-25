using RestaurantOrderWebApi.Domain.Dtos.Request;
using RestaurantOrderWebApi.Domain.Dtos.Response;

namespace RestaurantOrderWebApi.Domain.Interfaces.Service.Services
{
    public interface IOrderService
    {
        OrderResponseDto CreateOrder(OrderRequestDto orderRequestDto);
    }
}
