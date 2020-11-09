namespace ToyBlockFactory
{
    public class PaintingReport :IReport
    {
        private IConsoleIO _consoleIO;
        private IReportTable _reportTable;
        private IStandardReportMessages _standardReportMessages;

        public string ReportType { get; } = "Painting Report";
        
        public PaintingReport(IConsoleIO consoleIO, IReportTable reportTable, IStandardReportMessages standardReportMessages)
        {
            _consoleIO = consoleIO;
            _reportTable = reportTable;
            _standardReportMessages = standardReportMessages;
        }
        public void GenerateReport(IOrder order)
        {
            _consoleIO.Write(
                _standardReportMessages.GenerateReportConfirmation(ReportType) +
                _standardReportMessages.DisplayCustomerDetails(order) +
                _reportTable.CreateTable(order)
            );
        }
    }
}