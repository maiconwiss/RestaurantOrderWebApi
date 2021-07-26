using RestaurantOrderWebApi.Domain.Entities;
using RestaurantOrderWebApi.Domain.Interfaces.Data;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Validators;
using System.Collections.Generic;


namespace RestaurantOrderWebApi.Service.Validators
{
    public class OrderRequestDtoValidator : IOrderRequestDtoValidator
    {
        private readonly IDishRepository _dishRepository;

        public OrderRequestDtoValidator(IDishRepository _dishRepository)
        {
            this._dishRepository = _dishRepository;
        }

        public string Validate(IList<string> listStrings)
        {
            var timeOfday = listStrings[0].ToUpper();

            var resultValidateTimeOfDay = ValidateTimeOfDay(timeOfday);

            if (resultValidateTimeOfDay != null)
            {
                return resultValidateTimeOfDay;
            }

            var listDishes = GetAllDishes(listStrings);

            return ValidateDishes(timeOfday, listDishes);
        }

        private static IList<string> GetAllDishes(IList<string> listStrings)
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
            if (listDishes.Count == 0)
            {
                return "Please enter with at least one Dish";
            }
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

        private string ValidateDishesOfNight(IEnumerable<string> listDishes)
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
                    var dishesOfNight = _dishRepository.GetDishesOfNight();
                    var resultDishesOfNightToChoose = GetResultDishesOfNightToChoose(dishesOfNight);

                    return resultDishesOfNightToChoose;
                }
            }
            return null;
        }

        private string ValidateDishesOfMorning(IEnumerable<string> listDishes)
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
                    var dishesOfMorning = _dishRepository.GetDishesOfMorning();
                    var resultDishesOfMorningToChoose = GetResultDishesOfMorningToChoose(dishesOfMorning);

                    return resultDishesOfMorningToChoose;
                }
            }
            return null;
        }

        private static string GetResultDishesOfMorningToChoose(IEnumerable<DishMorning> dishes)
        {
            var resultDishesOfMorningToChoose = "Choose the following options when select Morning: ";

            foreach (var item in dishes)
            {
                resultDishesOfMorningToChoose += $"{item.Id}-{item.Description} ";
            }

            return resultDishesOfMorningToChoose;
        }

        private static string GetResultDishesOfNightToChoose(IEnumerable<DishNight> dishes)
        {
            var resultDishesOfNightToChoose = "Choose the following options when select Night: ";

            foreach (var item in dishes)
            {
                resultDishesOfNightToChoose += $"{item.Id}-{item.Description} ";
            }

            return resultDishesOfNightToChoose;
        }
    }
}
