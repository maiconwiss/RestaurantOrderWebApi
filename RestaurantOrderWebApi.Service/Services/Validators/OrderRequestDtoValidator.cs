using RestaurantOrderWebApi.Domain.Entities;
using RestaurantOrderWebApi.Domain.Interfaces;
using RestaurantOrderWebApi.Domain.Interfaces.Data;
using System.Collections.Generic;


namespace RestaurantOrderWebApi.Service.Services.Validators
{
    public class OrderRequestDtoValidator : IOrderRequestDtoValidator
    {
        private readonly IDishRepository _dishRepository;

        public OrderRequestDtoValidator(IDishRepository _dishRepository)
        {
            this._dishRepository = _dishRepository;
        }

        public string Validate(List<string> listStrings)
        {
            var timeOfday = listStrings[0].ToUpper();
            var resultTimeOfday = ValidateTimeOfDay(timeOfday);
            if (resultTimeOfday != null)
            {
                return resultTimeOfday;
            }

            var listDishes = GetAllDishes(listStrings);

            return ValidateDishes(timeOfday, listDishes);
        }

        private static List<string> GetAllDishes(List<string> listStrings)
        {
            var listDishes = new List<string>();
            var position = 1;

            foreach (var item in listStrings)
            {
                if (position == 1)
                {
                   position += position;
                }
                else
                {
                    listDishes.Add(item);
                }
            }
            return listDishes;
        }

        private static string ValidateTimeOfDay(string timeOfday)
        {
            if (timeOfday == "MORNING" || timeOfday == "NIGHT")
            {
                return null;
            }
            return "Please select morning or night";
        }

        private string ValidateDishes(string timeOfday, IList<string> listDishes)
        {
            if (timeOfday == "MORNING")
            {
                return ValidateDishesOfMorning(listDishes);
            }
            if (timeOfday == "NIGHT")
            {
                return ValidateDishesOfNight(listDishes);
            }

            return null;
        }

        private string ValidateDishesOfNight(IList<string> listDishes)
        {
            foreach (var item in listDishes)
            {
                if (!int.TryParse(item, out var dishId))
                {
                    dishId = 999;
                }

                var dishDescription = _dishRepository.GetDishOfNightById(dishId);

                if (dishDescription == null)
                {
                    var list = _dishRepository.GetDishesOfNight();

                    var stringResult = GetStringResultDishesOfNightToChoose(list);
                    return stringResult;
                }
            }
            return null;
        }

        private string ValidateDishesOfMorning(IList<string> listDishes)
        {
            foreach (var item in listDishes)
            {
                if (!int.TryParse(item, out var dishId))
                {
                    dishId = 999;
                }

                var dishDescription = _dishRepository.GetDishOfMorningById(dishId);

                if (dishDescription == null)
                {
                    var list = _dishRepository.GetDishesOfMorning();

                    var stringResult = GetStringResultDishesOfMorningToChoose(list);
                    return stringResult;
                }
            }
            return null;
        }

        private static string GetStringResultDishesOfMorningToChoose(List<DishMorning> dishes)
        {
            var stringResult = "Choose the following options on Morning: ";

            foreach (var item in dishes)
            {
                stringResult += $"{item.Id}-{item.Description} ";
            }

            return stringResult;
        }

        private static string GetStringResultDishesOfNightToChoose(List<DishNight> dishes)
        {
            var stringResult = "Choose the following options on Night: ";

            foreach (var item in dishes)
            {
                stringResult += $"{item.Id}-{item.Description} ";
            }

            return stringResult;
        }
    }
}
