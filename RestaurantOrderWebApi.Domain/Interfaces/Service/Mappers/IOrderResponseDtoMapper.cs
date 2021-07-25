using RestaurantOrderWebApi.Domain.Dtos.Response;
using RestaurantOrderWebApi.Domain.Entities;

namespace RestaurantOrderWebApi.Domain.Interfaces.Service.Mappers
{
    public interface IOrderResponseDtoMapper
    {
        OrderResponseDto MapToDto(Order order);
    }
}
