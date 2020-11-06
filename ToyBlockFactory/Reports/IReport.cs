namespace ToyBlockFactory
{
    public interface IReport
    {
        string ReportType {get;}
        void GenerateReport(IOrder order);
    }
}