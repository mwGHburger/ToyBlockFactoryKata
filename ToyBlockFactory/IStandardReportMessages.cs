namespace ToyBlockFactory
{
    public interface IStandardReportMessages
    {
         string GenerateReportConfirmation(string reportType);
         string DisplayCustomerDetails(IOrder order);
    }
}