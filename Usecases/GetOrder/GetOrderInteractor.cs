using OrderManagement.Entities;
using OrderManagement.Repository;

namespace OrderManagement.Usecases.GetOrder
{
    public class GetOrderInteractor
    {
        private readonly IOrderRepository _repository;

        public GetOrderInteractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Execute(string orderId)
        {
            var order = _repository.Find(orderId);
            return order;
        }
    }
}