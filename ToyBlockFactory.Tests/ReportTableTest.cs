using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class ReportTableTest
    {
        // [Fact]
        // public void CreateTableHeader_ShouldReturnTableHeaderString()
        // {
        //     var columns = SetupColumns();
        //     var longestRowLength = 8;
        //     var mockFieldData = new Mock<IFieldData>();
        //     var reportTable = new ReportTable(mockFieldData.Object);
        //     var expected = "|          | Red | Blue | Yellow |\n";

        //     var actual = reportTable.CreateTableHeader(columns,longestRowLength);

        //     Assert.Equal(expected, actual);
        // }

        // [Fact]
        // public void CreateTableBreaker_ShouldReturnTableBreakerString()
        // {
        //     var columns = SetupColumns();
        //     var longestRowLength = 8;
        //     var mockFieldData = new Mock<IFieldData>();
        //     var reportTable = new ReportTable(mockFieldData.Object);
        //     var expected = "|----------|-----|------|--------|\n";

        //     var actual = reportTable.CreateTableBreaker(columns, longestRowLength);

        //     Assert.Equal(expected, actual);
        // }

        // [Fact]
        // public void CreateTableBody_ShouldReturnTableBodyString()
        // {
        //     var columns = SetupColumns();
        //     var rows = SetupRows();
        //     var longestRowLength = 8;
        //     var mockOrder = new Mock<IOrder>();
        //     var mockFieldData = new Mock<IFieldData>();
        //     var reportTable = new ReportTable(mockFieldData.Object);
        //     var expected = "| Square   | 1   | -    | 1      |\n" +
        //                    "| Triangle | -   | 2    | -      |\n" +
        //                    "| Circle   | -   | 1    | 2      |\n";

        //     mockFieldData.SetupSequence(x => x.DetermineTableFieldData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IOrder>()))
        //     .Returns("1")
        //     .Returns("-")
        //     .Returns("1")
        //     .Returns("-")
        //     .Returns("2")
        //     .Returns("-")
        //     .Returns("-")
        //     .Returns("1")
        //     .Returns("2");

        //     var actual = reportTable.CreateTableBody(mockOrder.Object, rows, columns, longestRowLength);

        //     Assert.Equal(expected, actual);
        // }

        [Fact]
        public void CreateTable_ShouldGenerateTableString()
        {
            var mockFieldData = new Mock<IFieldData>();
            var columns = SetupColumns();
            var rows = SetupRows();
            var longestRowLength = 8;
            var mockOrder = new Mock<IOrder>();
            var reportTable = new ReportTable(columns, rows, longestRowLength,mockFieldData.Object);
            var expected = "|          | Red | Blue | Yellow |\n" +
            "|----------|-----|------|--------|\n" +
            "| Square   | 1   | -    | 1      |\n" +
            "| Triangle | -   | 2    | -      |\n" +
            "| Circle   | -   | 1    | 2      |\n";

            
            mockFieldData.SetupSequence(x => x.DetermineTableFieldData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IOrder>()))
            .Returns("1")
            .Returns("-")
            .Returns("1")
            .Returns("-")
            .Returns("2")
            .Returns("-")
            .Returns("-")
            .Returns("1")
            .Returns("2");

            var actual = reportTable.CreateTable(mockOrder.Object);

            Assert.Equal(expected, actual);
        }

        private List<string> SetupColumns()
        {
            var columns = new List<string>()
            {
                new Red().Name,
                new Blue().Name,
                new Yellow().Name
            };
            return columns;
        }

        private List<string> SetupRows()
        {
            var rows = new List<string>()
            {
                new Square().Name,
                new Triangle().Name,
                new Circle().Name
            };
            return rows;
        }
    }
}