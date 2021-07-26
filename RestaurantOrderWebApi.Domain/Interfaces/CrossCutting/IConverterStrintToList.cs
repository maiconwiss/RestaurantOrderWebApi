using System.Collections.Generic;

namespace RestaurantOrderWebApi.Domain.Interfaces.CrossCutting
{
    public interface IConverterStrintToList
    {
        IList<string> Converter(string value);
    }
}
