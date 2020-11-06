namespace ToyBlockFactory
{
    public class StandardReportMessages
    {
        public string GenerateReportConfirmation(string reportType)
        {
            return $"Your {reportType} has been generated:\n\n";
        }

        public string DisplayCustomerDetails(IOrder order)
        {
            return $"Name: {order.CustomerName} Address: {order.Address} Due Date: {order.DueDate} Order #: {order.OrderNumber}\n\n";
        }
    }
}