using System.Collections.Generic;

namespace RestaurantOrderWebApi.Domain.Interfaces
{
    public interface IOrderRequestDtoValidator
    {
        string Validate(List<string> listStrings);
    }
}
