using OrderManagement.Entities;

namespace OrderManagement.Repository
{
    public interface IOrderRepository
    {
        public Order Find(string orderId);
        public void Save(Order order);
    }
}