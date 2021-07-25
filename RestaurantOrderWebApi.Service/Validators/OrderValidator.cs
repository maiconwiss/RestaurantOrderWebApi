using FluentValidation;
using RestaurantOrderWebApi.Domain.Entities;

namespace RestaurantOrderWebApi.Service.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(c => c.Dishes)
                .NotEmpty().WithMessage("Please enter at least one Dish");
        }
    }
}
