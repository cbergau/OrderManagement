using OrderManagement.Entities;
using OrderManagement.Repository;

namespace OrderManagement.UseCases.GetOrder
{
    public class GetOrderUseCase
    {
        private readonly IOrderRepository _repository;
        private readonly IGetOrderPresenter _presenter;

        public GetOrderUseCase(IOrderRepository repository, IGetOrderPresenter presenter)
        {
            _repository = repository;
            _presenter = presenter;
        }

        public void Execute(string orderId)
        {
            var order = _repository.Find(orderId);
            _presenter.Present(new OrderResponseModel
            {
                id = order.Id, state = (int) order.State
            });
        }
    }
}