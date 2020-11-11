namespace ToyBlockFactory
{
    public class OrderNumberTracker : IOrderNumberTracker
    {
        private int _currentOrderNumber = 0;

        public string GetNewOrderNumber()
        {
            IncrementOrderNumber();
            char pad = '0';
            return _currentOrderNumber.ToString().PadLeft(4, pad);
        }

        private void IncrementOrderNumber()
        {
            _currentOrderNumber += 1;
        }
    }
}