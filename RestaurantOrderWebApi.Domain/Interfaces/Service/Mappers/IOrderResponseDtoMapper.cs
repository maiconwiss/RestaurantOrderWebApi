using RestaurantOrderWebApi.Domain.Entities;

namespace RestaurantOrderWebApi.Domain.Interfaces.Service.Mappers
{
    public interface IOrderResponseDtoMapper
    {
        string MapToDto(Order order);
    }
}
