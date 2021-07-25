using RestaurantOrderWebApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrderWebApi.Service.Services.Mappers
{
    public class MorningFinalOrderGenerator : BaseFinalOrderGenetator
    {
        public MorningFinalOrderGenerator(IEnumerable<Dish> dishes)
            : base(dishes)
        {
        }
     
        public override string GenerateFinalOrder()
        {
            var listString = new List<string>();

            var dishesMap = GetDictionaryDishesTimes(Dishes.Select(a => a.Id));

            foreach (var item in dishesMap)
            {
                var description = Dishes.Where(a => a.Id == item.Key).FirstOrDefault().Description;

                if (item.Key != 3 && item.Value > 1)
                {
                    listString.Add($"{description}, error");
                }
                else if (item.Key == 3 && item.Value > 1)
                {
                    listString.Add($"{description}(x{item.Value})");
                }
                else
                {
                    listString.Add($"{description}");
                }
            }

            var stringResult = string.Join(", ", listString);

            return stringResult;
        }
    }
}
