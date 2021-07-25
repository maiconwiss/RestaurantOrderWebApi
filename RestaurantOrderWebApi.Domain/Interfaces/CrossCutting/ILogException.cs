using System;

namespace RestaurantOrderWebApi.Domain.Interfaces.CrossCutting
{
    public interface ILogException
    {
        void CreateLog(Exception ex);
    }
}
