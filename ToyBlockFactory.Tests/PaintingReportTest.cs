using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class PaintingReportTest
    {
        [Fact]
        public void GenerateReport_ShouldGeneratePaintingReportString()
        {
            var mockOrder = new Mock<IOrder>();
            var mockConsoleIO = new Mock<IConsoleIO>();
            var mockReportTable = new Mock<IReportTable>();
            var mockStandardReportMessages = new Mock<IStandardReportMessages>();
            var paintingReport = new PaintingReport(mockConsoleIO.Object, mockReportTable.Object, mockStandardReportMessages.Object);

            mockStandardReportMessages.Setup(x => x.GenerateReportConfirmation("Painting Report")).Returns("Your painting report has been generated:\n\n");
            mockStandardReportMessages.Setup(x => x.DisplayCustomerDetails(It.IsAny<IOrder>())).Returns("Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001:\n\n");
            mockReportTable.Setup(x => x.CreateTable(It.IsAny<IOrder>())).Returns(
                "|          | Red | Blue | Yellow |\n" +
                "|----------|-----|------|--------|\n" +
                "| Square   | 1   | -    | 1      |\n" +
                "| Triangle | -   | 2    | -      |\n" +
                "| Circle   | -   | 1    | 2      |\n"
            );

            paintingReport.GenerateReport(mockOrder.Object);

            mockConsoleIO.Verify(x => x.Write(
                "Your painting report has been generated:\n\n" +
                "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001:\n\n" +
                "|          | Red | Blue | Yellow |\n" +
                "|----------|-----|------|--------|\n" +
                "| Square   | 1   | -    | 1      |\n" +
                "| Triangle | -   | 2    | -      |\n" +
                "| Circle   | -   | 1    | 2      |\n"
            ), Times.Exactly(1));
        }
    }
}