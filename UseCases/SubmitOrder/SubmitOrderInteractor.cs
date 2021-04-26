using OrderManagement.Entities;
using OrderManagement.Repository;

namespace OrderManagement.UseCases.SubmitOrder
{
    public class SubmitOrderInteractor
    {
        private readonly IOrderRepository _repository;

        public SubmitOrderInteractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Execute()
        {
            var order = new Order();
            _repository.Save(order);
            return order;
        }
    }
}