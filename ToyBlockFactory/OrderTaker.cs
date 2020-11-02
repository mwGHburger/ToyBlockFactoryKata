namespace ToyBlockFactory
{
    public class OrderTaker
    {
        private IBuyerInformationCollector _buyerInformationCollector;
        private IOrderListGenerator _orderListGenerator;
        private IOrderNumberTracker _orderNumberTracker;

        public OrderTaker(IBuyerInformationCollector buyerInformationCollector, IOrderListGenerator orderListGenerator, IOrderNumberTracker orderNumberTracker)
        {
            _buyerInformationCollector = buyerInformationCollector;
            _orderListGenerator = orderListGenerator;
            _orderNumberTracker = orderNumberTracker;
        }
        public Order TakeSingleOrder()
        {
            var customerInformation = _buyerInformationCollector.GetBuyerInformation();
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