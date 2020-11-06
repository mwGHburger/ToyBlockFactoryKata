using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ReportsGenerator
    {
        private List<IReport> _reports;

        public ReportsGenerator(List<IReport> reports)
        {
            _reports = reports;
        }

        public void GenerateReportsForSingleOrder(IOrder order)
        {
            foreach(IReport report in _reports)
            {
                report.GenerateReport(order);
            }
        }
    }
}