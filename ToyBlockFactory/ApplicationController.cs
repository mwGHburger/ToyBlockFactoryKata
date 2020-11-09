namespace ToyBlockFactory
{
    public class ApplicationController
    {
        private IOrderTaker _orderTaker;
        private IReportGenerator _reportGenerator;

        public ApplicationController(IOrderTaker orderTaker, IReportGenerator reportGenerator)
        {
            _orderTaker = orderTaker;
            _reportGenerator = reportGenerator;
        }

        public void HandleSingleOrder()
        {
            var order = _orderTaker.TakeSingleOrder();
            _reportGenerator.GenerateReportsForSingleOrder(order);
        }
        
    }
}