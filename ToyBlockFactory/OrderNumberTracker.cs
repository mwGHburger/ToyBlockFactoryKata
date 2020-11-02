namespace ToyBlockFactory
{
    public class OrderNumberTracker : IOrderNumberTracker
    {
        private int _currentOrderNumber = 0;

        public string GetNewOrderNumber()
        {
            // TODO: make this more dynamic
            _currentOrderNumber += 1;
            return $"000{_currentOrderNumber}";
        }
    }
}