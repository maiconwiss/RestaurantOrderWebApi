using RestaurantOrderWebApi.Domain.Dtos.Request;
using RestaurantOrderWebApi.Domain.Interfaces.CrossCutting;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Factories;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Mappers;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Services;
using RestaurantOrderWebApi.Domain.Interfaces.Service.Validators;
using System;

namespace RestaurantOrderWebApi.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IConverterStrintToList _converterStrintToList;
        private readonly IOrderFactory _orderFactory;
        private readonly IOrderResponseDtoMapper _orderResponseDtoMapper;
        private readonly ILogException _logException;
        private readonly IOrderRequestDtoValidator _orderRequestDtoValidator;

        public OrderService(IConverterStrintToList _converterStrintToList, 
            IOrderFactory _orderFactory, 
            IOrderResponseDtoMapper _orderResponseDtoMapper,
            ILogException _logException,
            IOrderRequestDtoValidator _orderRequestDtoValidator)
        {
            this._converterStrintToList = _converterStrintToList;
            this._orderFactory = _orderFactory;
            this._orderResponseDtoMapper = _orderResponseDtoMapper;
            this._logException = _logException;
            this._orderRequestDtoValidator = _orderRequestDtoValidator;
        }

        public string CreateOrder(OrderRequestDto orderRequestDto)
        {
            string orderResponseDto = "";

            try
            {             
                var listStrings = _converterStrintToList.Converter(orderRequestDto.Input.Trim());

                var resultOrderRequestDtoValidator = _orderRequestDtoValidator.Validate(listStrings);

                if (resultOrderRequestDtoValidator != null)
                {                    
                    return resultOrderRequestDtoValidator;
                }

                var order = _orderFactory.Create(listStrings);

                orderResponseDto = _orderResponseDtoMapper.MapToDto(order);                
            }
            catch (Exception ex)
            {
                _logException.CreateLog(ex);
            }

            return orderResponseDto;
        }
    }
}
