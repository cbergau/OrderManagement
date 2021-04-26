using System;
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

        public void Execute(string orderId)
        {
            try
            {
                var order = _repository.Find(orderId);
                order.Cancel();
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