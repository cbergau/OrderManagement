using OrderManagement.Entities;
using OrderManagement.Repository;

namespace OrderManagement.Usecases.CancelOrder
{
    public class CancelOrderInteractor
    {
        private readonly IOrderRepository _repository;

        public CancelOrderInteractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Execute(string orderId)
        {
            var order = _repository.Find(orderId);
            order.Cancel();
            _repository.Save(order);
            return order;
        }
    }
}
