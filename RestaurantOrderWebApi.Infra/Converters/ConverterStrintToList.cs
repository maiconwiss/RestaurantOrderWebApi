using RestaurantOrderWebApi.Domain.Interfaces.CrossCutting;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrderWebApi.Infra.CrossCutting.Converters
{
    public class ConverterStrintToList : IConverterStrintToList
    {
        public IList<string> Converter(string value)
        {
            IList<string> list = value.Split(',').Select(a => a).ToList();
            return list;
        }
    }
}
