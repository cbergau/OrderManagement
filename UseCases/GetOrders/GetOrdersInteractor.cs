using System.Collections.Generic;
using OrderManagement.Entities;
using OrderManagement.Repository;

namespace OrderManagement.UseCases.GetOrders
{
    public class GetOrdersInteractor
    {
        private readonly IOrderRepository _repository;

        public GetOrdersInteractor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Order> Execute()
        {
            return _repository.FindAll();
        }
    }
}