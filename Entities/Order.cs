namespace OrderManagement.Entities
{
    public class Order
    {
        private string ID;
        private int state;

        public int State
        {
            get => state;
            set => state = value;
        }

        public string Id
        {
            get => ID;
            set => ID = value;
        }

        public void Cancel()
        {
            state = 1;
        }
    }
}