using RestaurantOrderWebApi.Domain.Dtos.Request;

namespace RestaurantOrderWebApi.Domain.Interfaces.Service.Services
{
    public interface IOrderService
    {
        string CreateOrder(OrderRequestDto orderRequestDto);
    }
}
