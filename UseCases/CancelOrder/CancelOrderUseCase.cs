﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrderManagement.Entities.Exceptions;
using OrderManagement.Repository;

namespace OrderManagement.UseCases.CancelOrder
{
    public class CancelOrderUseCase
    {
        private readonly IOrderRepository _repository;
        private readonly ICancelOrderPresenter _presenter;

        public CancelOrderUseCase(IOrderRepository repository, ICancelOrderPresenter presenter)
        {
            _repository = repository;
            _presenter = presenter;
        }

        public void Execute(string orderId, CancelOrderRequest request)
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(request);
            var isValid = Validator.TryValidateObject(request, context, errors, true);

            if (!isValid)
            {
                _presenter.PresentValidationErrors(errors);
                return;
            }

            try
            {
                var order = _repository.Find(orderId);
                order.Cancel(request.Reason);
                _repository.Save(order);
                _presenter.PresentSuccess();
            }
            catch (OrderAlreadyCancelledException)
            {
                _presenter.PresentDomainError("ORDER_ALREADY_CANCELLED");
            }
            catch (Exception)
            {
                _presenter.PresentError();
            }
        }
    }
}