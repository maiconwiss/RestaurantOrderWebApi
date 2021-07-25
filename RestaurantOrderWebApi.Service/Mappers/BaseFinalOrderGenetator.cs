using RestaurantOrderWebApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrderWebApi.Service.Mappers
{
    public abstract class BaseFinalOrderGenetator
    {
        protected IEnumerable<Dish> Dishes { get; private set; }
        public BaseFinalOrderGenetator(IEnumerable<Dish> dishes)
        {
            Dishes = dishes;
        }
        public abstract string GenerateFinalOrder();

        protected static Dictionary<int, int> GetDictionaryDishesTimes(IEnumerable<int> dishes)
        {
            return dishes.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }
    }
}
