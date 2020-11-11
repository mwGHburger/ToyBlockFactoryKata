using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class CuttingListReportTest
    {
        [Fact]
        public void GenerateReport_ShouldGenerateCuttingListReport()
        {
            var blocks = TestHelper.SetupBlocks();  
            var mockOrder = new Mock<IOrder>();
            var mockConsoleIO = new Mock<IConsoleIO>();
            var mockStandardReportMessages = new Mock<IStandardReportMessages>();
            var mockReportTable = new Mock<IReportTable>();

            var cuttingListReport = new CuttingListReport(mockConsoleIO.Object, mockStandardReportMessages.Object, mockReportTable.Object);

            mockStandardReportMessages.Setup(x => x.GenerateReportConfirmation("Cutting List")).Returns("Your Cutting List has been generated:\n\n");
            mockStandardReportMessages.Setup(x => x.DisplayCustomerDetails(It.IsAny<IOrder>())).Returns("Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n\n");
            mockOrder.Setup(x => x.Blocks).Returns(blocks);
            mockReportTable.Setup(x => x.CreateTable(It.IsAny<IOrder>())).Returns(
                "|          | Qty |\n" +
                "|----------|-----|\n" +
                "| Square   | 2   |\n" +
                "| Triangle | 2   |\n" +
                "| Circle   | 3   |\n"
            );

            cuttingListReport.GenerateReport(mockOrder.Object);

            mockConsoleIO.Verify(x => x.Write(
            "Your Cutting List has been generated:\n\n" +
            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n\n" +
            "|          | Qty |\n" +
            "|----------|-----|\n" +
            "| Square   | 2   |\n" +
            "| Triangle | 2   |\n" +
            "| Circle   | 3   |\n"
            ), Times.Exactly(1));
        }
    }
}