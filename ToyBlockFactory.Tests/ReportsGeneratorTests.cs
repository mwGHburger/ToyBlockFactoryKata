using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class ReportsGeneratorTest
    {
        [Fact]
        public void GenerateReports_ShouldGenerateVariousReportTypesForGivenOrder()
        {
            var mockInvoiceReport = new Mock<IReport>();
            var mockCuttingListReport = new Mock<IReport>();
            var mockPaintingReport = new Mock<IReport>();
            var reportTypes = new List<IReport>
            {
                mockInvoiceReport.Object,
                mockCuttingListReport.Object,
                mockPaintingReport.Object
            };
            var mockOrder = new Mock<IOrder>();
            var reportsGenerator = new ReportGenerator(reportTypes);

            reportsGenerator.GenerateReportsForSingleOrder(mockOrder.Object);

            mockInvoiceReport.Verify(x => x.GenerateReport(mockOrder.Object), Times.Exactly(1));
            mockCuttingListReport.Verify(x => x.GenerateReport(mockOrder.Object), Times.Exactly(1));
            mockPaintingReport.Verify(x => x.GenerateReport(mockOrder.Object), Times.Exactly(1));
        }
    }
}