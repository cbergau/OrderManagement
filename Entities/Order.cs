namespace OrderManagement.Entities
{
    public class Order
    {
        public int State { get; set; }

        public string Id { get; set; }

        public void Cancel()
        {
            State = 1;
        }
    }
}