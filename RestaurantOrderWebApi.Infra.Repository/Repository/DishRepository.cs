using RestaurantOrderWebApi.Domain.Entities;
using RestaurantOrderWebApi.Domain.Interfaces.Data;
using System.Collections.Generic;

namespace RestaurantOrderWebApi.Infra.Data.Repository
{
    public class DishRepository : IDishRepository
    {
        //repository com dados mockados
        public List<DishMorning> GetDishesOfMorning()
        {
            var dishMornings = new List<DishMorning>
            {
                new DishMorning { Id = 1, Description = "eggs" },
                new DishMorning { Id = 2, Description = "toast" },
                new DishMorning { Id = 3, Description = "coffee" }
            };

            return dishMornings;
        }

        public List<DishNight> GetDishesOfNight()
        {
            var dishNights = new List<DishNight>
            {
                new DishNight { Id = 1, Description = "steak" },
                new DishNight { Id = 2, Description = "potato" },
                new DishNight { Id = 3, Description = "wine" },
                new DishNight { Id = 4, Description = "cake" }
            };

            return dishNights;
        }

        public string GetDishOfMorningById(int dish)
        {
            return dish switch
            {
                1 => "eggs",
                2 => "toast",
                3 => "coffee",
                4 => "error",
                _ => null,
            };
        }

        public string GetDishOfNightById(int dish)
        {
            return dish switch
            {
                1 => "steak",
                2 => "potato",
                3 => "wine",
                4 => "cake",
                _ => null,
            };
        }
    }
}
