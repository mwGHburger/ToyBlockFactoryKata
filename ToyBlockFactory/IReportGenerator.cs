namespace ToyBlockFactory
{
    public interface IReportGenerator
    {
        void GenerateReportsForSingleOrder(IOrder order);
    }
}