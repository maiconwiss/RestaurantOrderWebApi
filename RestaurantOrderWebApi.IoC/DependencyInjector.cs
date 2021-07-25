using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderWebApi.Domain.Interfaces.CrossCutting;
using RestaurantOrderWebApi.Domain.Interfaces.Data;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Factories;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Mappers;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Services;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Validators;
using RestaurantOrderWebApi.Infra.CrossCutting.Converters;
using RestaurantOrderWebApi.Infra.CrossCutting.Logs;
using RestaurantOrderWebApi.Infra.Data.Repository;
using RestaurantOrderWebApi.Service.Factories;
using RestaurantOrderWebApi.Service.Mappers;
using RestaurantOrderWebApi.Service.Services;
using RestaurantOrderWebApi.Service.Validators;

namespace RestaurantOrderWebApi.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            RegisterCrossCutting(services);
            RegisterServices(services);
            RegisterData(services);
        }
        private static void RegisterCrossCutting(IServiceCollection services)
        {
            services.AddSingleton<IConverterStrintToList, ConverterStrintToList>();
            services.AddSingleton<ILogException, LogException>();            
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IOrderFactory, OrderFactory>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderResponseDtoMapper, OrderResponseDtoMapper>();
            services.AddScoped<IOrderRequestDtoValidator, OrderRequestDtoValidator>();            
        }
        private static void RegisterData(IServiceCollection services)
        {
            services.AddScoped<IDishRepository, DishRepository>();
        }
    }
}
