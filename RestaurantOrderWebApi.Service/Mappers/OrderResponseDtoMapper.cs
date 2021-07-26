using RestaurantOrderWebApi.Domain.Entities;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Mappers;

namespace RestaurantOrderWebApi.Service.Mappers
{
    public class OrderResponseDtoMapper : IOrderResponseDtoMapper
    {

        public string MapToDto(Order order) {

            string orderResponseDto;

            switch (order.TimeOfDay.ToUpper())
            {
                case "MORNING":
                    orderResponseDto = new MorningFinalOrderGenerator(order.Dishes).GenerateFinalOrder();
                    break;
                case "NIGHT":
                    orderResponseDto = new NightFinalOrderGenerator(order.Dishes).GenerateFinalOrder();
                    break;
                default:
                    orderResponseDto = "error";
                    break;
            }

            return orderResponseDto;
        }
    }
}
