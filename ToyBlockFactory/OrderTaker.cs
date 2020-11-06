namespace ToyBlockFactory
{
    public class OrderTaker
    {
        private ICustomerInformationCollector _customerInformationCollector;
        private IOrderListGenerator _orderListGenerator;
        private IOrderNumberTracker _orderNumberTracker;

        public OrderTaker(ICustomerInformationCollector customerInformationCollector, IOrderListGenerator orderListGenerator, IOrderNumberTracker orderNumberTracker)
        {
            _customerInformationCollector = customerInformationCollector;
            _orderListGenerator = orderListGenerator;
            _orderNumberTracker = orderNumberTracker;
        }
        public Order TakeSingleOrder()
        {
            var customerInformation = _customerInformationCollector.GetCustomerInformation();
            var blocksList = _orderListGenerator.GetBlockOrderItemsDetails();
            var newOrderNumber = _orderNumberTracker.GetNewOrderNumber();
            return new Order(
                customerInformation.Name, 
                customerInformation.Address,
                customerInformation.DueDate,
                newOrderNumber,
                blocksList
            );
        }
    }
}