using RestaurantOrderWebApi.Domain.Entities;
using System.Collections.Generic;

namespace RestaurantOrderWebApi.Domain.Interfaces.Data
{
    public interface IDishRepository 
    {
        List<DishMorning> GetDishesOfMorning();
        List<DishNight> GetDishesOfNight();
        string GetDishOfMorningById(int dish);
        string GetDishOfNightById(int dish);
    }
}
