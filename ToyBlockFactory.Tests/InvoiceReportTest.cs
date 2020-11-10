using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class InvoiceReportTest
    {
        [Fact]
        public void GenerateReport_ShouldDisplayOrderDetailsToConsole()
        {
            var colours = SetupColours();
            var shapes = SetupShapes();
            var blocks = SetupBlocks();            
            
            var mockConsoleIO = new Mock<IConsoleIO>();
            var mockOrder = new Mock<IOrder>();
            var mockStandardReportMessages = new Mock<IStandardReportMessages>();
            var mockReportTable = new Mock<IReportTable>();

            var invoiceReport = new InvoiceReport(mockConsoleIO.Object, colours, shapes,mockStandardReportMessages.Object, mockReportTable.Object);

            mockOrder.Setup(x => x.CustomerName).Returns("Mark Pearl");
            mockOrder.Setup(x => x.Address).Returns("1 Bob Avenue, Auckland");
            mockOrder.Setup(x => x.DueDate).Returns("19 Jan 2019");
            mockOrder.Setup(x => x.OrderNumber).Returns("0001");
            mockOrder.Setup(x => x.Blocks).Returns(blocks);
            mockStandardReportMessages.Setup(x => x.GenerateReportConfirmation("Invoice Report")).Returns("Your Invoice Report has been generated:\n\n");
            mockStandardReportMessages.Setup(x => x.DisplayCustomerDetails(It.IsAny<IOrder>())).Returns("Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n\n");
            mockReportTable.Setup(x => x.CreateTable(It.IsAny<IOrder>())).Returns(
                "|          | Red | Blue | Yellow |\n" +
                "|----------|-----|------|--------|\n" +
                "| Square   | 1   | -    | 1      |\n" +
                "| Triangle | -   | 2    | -      |\n" +
                "| Circle   | -   | 1    | 2      |\n"
            );

            invoiceReport.GenerateReport(mockOrder.Object);

            mockConsoleIO.Verify(x => x.Write(
            "Your Invoice Report has been generated:\n\n" +
            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n\n" +
            "|          | Red | Blue | Yellow |\n" +
            "|----------|-----|------|--------|\n" +
            "| Square   | 1   | -    | 1      |\n" +
            "| Triangle | -   | 2    | -      |\n" +
            "| Circle   | -   | 1    | 2      |\n" +
            "Square         2 @ $1 ppi = $2\n" +
            "Triangle       2 @ $2 ppi = $4\n" +
            "Circle         3 @ $3 ppi = $9\n" +
            "Red color surcharge    1 @ $1 ppi = $1\n"
            ), Times.Exactly(1));
        }

        private List<IColour> SetupColours()
        {
            return new List<IColour>()
            {
                new Red(),
                new Blue(),
                new Yellow()
            };
        }

        private List<IShape> SetupShapes()
        {
            return new List<IShape>()
            {
                new Square(),
                new Triangle(),
                new Circle()
            };
        }

        private List<IBlockOrderItem> SetupBlocks()
        {
            return new List<IBlockOrderItem>()
            {
                new BlockOrderItem("Square", "Red", 1),
                new BlockOrderItem("Triangle", "Red", 0),
                new BlockOrderItem("Circle", "Red", 0),
                new BlockOrderItem("Square", "Blue", 0),
                new BlockOrderItem("Triangle", "Blue", 2),
                new BlockOrderItem("Circle", "Blue", 1),
                new BlockOrderItem("Square", "Yellow", 1),
                new BlockOrderItem("Triangle", "Yellow", 0),
                new BlockOrderItem("Circle", "Yellow", 2)
            };
        }

    }
}