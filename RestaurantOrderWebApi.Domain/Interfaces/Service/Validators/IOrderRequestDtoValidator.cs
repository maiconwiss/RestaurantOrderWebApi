using System.Collections.Generic;

namespace RestaurantOrderWebApi.Domain.Interfaces.Service.Validators
{
    public interface IOrderRequestDtoValidator
    {
        string Validate(IList<string> listStrings);
    }
}
