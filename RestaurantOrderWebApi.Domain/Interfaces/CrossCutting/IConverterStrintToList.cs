using System.Collections.Generic;

namespace RestaurantOrderWebApi.Domain.Interfaces.CrossCutting
{
    public interface IConverterStrintToList
    {
        List<string> Converter(string value);
    }
}
