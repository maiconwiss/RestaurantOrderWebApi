using RestaurantOrderWebApi.Domain.Entities;
using System.Collections.Generic;

namespace RestaurantOrderWebApi.Domain.Interfaces.Service.Factories
{
    public interface IOrderFactory
    {
        Order Create(IList<string> listStrings);
    }
}
