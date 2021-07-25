using FluentValidation.Results;
using RestaurantOrderWebApi.Domain.Dtos.Request;
using RestaurantOrderWebApi.Domain.Dtos.Response;
using RestaurantOrderWebApi.Domain.Interfaces;
using RestaurantOrderWebApi.Domain.Interfaces.CrossCutting;
using RestaurantOrderWebApi.Domain.Interfaces.Services;
using RestaurantOrderWebApi.Domain.Interfaces.Services.Factories;
using RestaurantOrderWebApi.Domain.Interfaces.Services.Mappers;
using RestaurantOrderWebApi.Service.Services.Validators;
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

        public OrderResponseDto CreateOrder(OrderRequestDto orderRequestDto)
        {
            OrderResponseDto orderResponseDto = new();

            try
            {             
                var listStrings = _converterStrintToList.Converter(orderRequestDto.Input.Trim());

                var resultValidation = _orderRequestDtoValidator.Validate(listStrings);

                if (resultValidation != null)
                {
                    orderResponseDto.Output = resultValidation;
                    return orderResponseDto;
                }

                var order = _orderFactory.Create(listStrings);

                OrderValidator validator = new();
                ValidationResult results = validator.Validate(order);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        orderResponseDto.Output = "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage;
                    }
                }
                else
                {
                    orderResponseDto = _orderResponseDtoMapper.MapToDto(order);
                }
            }
            catch (Exception ex)
            {
                _logException.CreateLog(ex);
            }
    
            return orderResponseDto;
        }
    }
}
