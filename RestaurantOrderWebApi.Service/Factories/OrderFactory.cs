using RestaurantOrderWebApi.Domain.Entities;
using RestaurantOrderWebApi.Domain.Interfaces.Data;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Factories;
using System.Collections.Generic;

namespace RestaurantOrderWebApi.Service.Factories
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IDishRepository _dishRepository;

        public OrderFactory(IDishRepository _dishRepository)
        {
            this._dishRepository = _dishRepository;
        }

        public Order Create(IList<string> listStrings) {

            var timeOfDay = GetTimeOfDay(listStrings);
            var dishesIds = GetDishIds(listStrings);
            var dishesOrdenedAscendent = GetDishesOrdenedAscendent(dishesIds);
            var dishes = GetDishes(dishesOrdenedAscendent, timeOfDay);

            var order = new Order
            {
                TimeOfDay = timeOfDay,
                Dishes = dishes
            };

            return order;
        }

        private static string GetTimeOfDay(IList<string> listStrings)
        {
            var timeOfday = listStrings[0];
            return timeOfday;
        }

        private static List<int> GetDishIds(IList<string> listStrings)
        {
            listStrings.RemoveAt(0);
            var listDishIds = new List<int>();

            foreach (var item in listStrings)
            {
                var dish = int.Parse(item);
                listDishIds.Add(dish);
            }   

            return listDishIds;
        }

        private static List<int> GetDishesOrdenedAscendent(List<int> dishesIds)
        {
            List<int> dishesOrdenedAscendent = dishesIds;
            dishesOrdenedAscendent.Sort();

            return dishesOrdenedAscendent;
        }

        private List<Dish> GetDishesMorningFinal(List<int> dishesIds)
        {
            var dishes = new List<Dish>();

            foreach (var item in dishesIds)
            {
                var dish = new Dish()
                {
                    Id = item,
                    Description = _dishRepository.GetDishOfMorningById(item)
                };
                dishes.Add(dish);
            }

            return dishes;
        }

        private List<Dish> GetDishesNigthFinal(List<int> dishesIds)
        {
            var dishes = new List<Dish>();

            foreach (var item in dishesIds)
            {
                var dish = new Dish()
                {
                    Id = item,
                    Description = _dishRepository.GetDishOfNightById(item)
                };
                dishes.Add(dish);
            }

            return dishes;
        }

        private List<Dish> GetDishes(List<int> dishesIds, string timeOfDay)
        {
            return timeOfDay.ToUpper() switch
            {
                "MORNING" => GetDishesMorningFinal(dishesIds),
                "NIGHT" => GetDishesNigthFinal(dishesIds),
                _ => new List<Dish>(),
            };
        }
    }
}
