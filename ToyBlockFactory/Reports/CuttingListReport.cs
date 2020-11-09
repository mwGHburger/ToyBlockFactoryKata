using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class CuttingListReport :  IReport
    {
        private IConsoleIO _consoleIO;
        private IStandardReportMessages _standardReportMessages;
        public string ReportType { get; } = "Cutting List";
        private IReportTable _reportTable;

        public CuttingListReport(IConsoleIO consoleIO, IStandardReportMessages standardReportMessages, IReportTable reportTable)
        {
            _consoleIO = consoleIO;
            _standardReportMessages = standardReportMessages;
            _reportTable = reportTable;
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