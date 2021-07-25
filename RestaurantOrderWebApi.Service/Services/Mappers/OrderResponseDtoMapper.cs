using RestaurantOrderWebApi.Domain.Dtos.Response;
using RestaurantOrderWebApi.Domain.Entities;
using RestaurantOrderWebApi.Domain.Interfaces.Services.Mappers;

namespace RestaurantOrderWebApi.Service.Services.Mappers
{
    public class OrderResponseDtoMapper : IOrderResponseDtoMapper
    {

        public OrderResponseDto MapToDto(Order order) {

            var orderResponseDto = new OrderResponseDto();

            switch (order.TimeOfDay.ToUpper())
            {
                case "MORNING":
                    orderResponseDto.Output = new MorningFinalOrderGenerator(order.Dishes).GenerateFinalOrder();
                    break;
                case "NIGHT":
                    orderResponseDto.Output = new NightFinalOrderGenerator(order.Dishes).GenerateFinalOrder();
                    break;
                default:
                    orderResponseDto.Output = "error";
                    break;
            }

            return orderResponseDto;
        }
    }
}
