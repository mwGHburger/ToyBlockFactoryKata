namespace ToyBlockFactory
{
    public class OrderNumberTracker : IOrderNumberTracker
    {
        private int _currentOrderNumber = 0;

        public string GetNewOrderNumber()
        {
            _currentOrderNumber += 1;
            char pad = '0';
            return _currentOrderNumber.ToString().PadLeft(4, pad);
        }
    }
}