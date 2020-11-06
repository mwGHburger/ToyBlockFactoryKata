namespace ToyBlockFactory
{
    public class PaintingReport :IReport
    {
        public string ReportType { get; } = "Painting Report";
        public void GenerateReport(IOrder order)
        {

        }
    }
}