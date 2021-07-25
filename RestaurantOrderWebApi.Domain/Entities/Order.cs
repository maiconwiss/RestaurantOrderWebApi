using System.Collections.Generic;

namespace RestaurantOrderWebApi.Domain.Entities
{
    public class Order
    {
        public string TimeOfDay { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}