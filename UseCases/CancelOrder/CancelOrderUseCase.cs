using System;
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
            // Validate Request (TODO THIS DOES NOT WORK YET)
            var r = new CancelOrderRequest {Reason = "a"};
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(r);
            var isValid = Validator.TryValidateObject(r, context, errors, true);

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