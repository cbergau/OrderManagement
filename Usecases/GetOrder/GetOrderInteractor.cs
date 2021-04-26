using OrderManagement.Entities;
using OrderManagement.Repository;

namespace OrderManagement.Usecases.GetOrder
{
    public class GetOrderInteractor
    {
        private readonly IOrderRepository _repository;
        private readonly IGetOrderPresenter _presenter;

        public GetOrderInteractor(IOrderRepository repository, IGetOrderPresenter presenter)
        {
            _repository = repository;
            _presenter = presenter;
        }

        public void Execute(string orderId)
        {
            var order = _repository.Find(orderId);
            _presenter.Present(new OrderResponseModel {id = order.Id, state = order.State});
        }
    }
}