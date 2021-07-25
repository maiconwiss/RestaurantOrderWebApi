using RestaurantOrderWebApi.Domain.Dtos.Response;
using RestaurantOrderWebApi.Domain.Entities;

namespace RestaurantOrderWebApi.Domain.Interfaces.Services.Mappers
{
    public interface IOrderResponseDtoMapper
    {
        OrderResponseDto MapToDto(Order order);
    }
}
