using OrderManagement.Entities.Exceptions;

namespace OrderManagement.Entities
{
    public class Order
    {
        public OrderStates State { get; set; }

        public string Id { get; set; }

        public void Cancel()
        {
            if (State == OrderStates.CANCELLED)
            {
                throw new OrderAlreadyCancelledException();
            }

            State = OrderStates.CANCELLED;
        }
    }
}