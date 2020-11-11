using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class InvoiceFieldDataTest
    {
        [Theory]
        [InlineData("Square", "Red", "1")]
        [InlineData("Triangle", "Yellow", "-")]
        public void DetermineTableFieldData_ShouldReturnStringData(string row, string column, string expected)
        {
            var blocks = TestHelper.SetupBlocks();
            var mockOrder = new Mock<IOrder>();
            var invoiceFieldData = new InvoiceFieldData();
            
            mockOrder.Setup(x => x.Blocks).Returns(blocks);
            
            var actual = invoiceFieldData.DetermineTableFieldData(mockOrder.Object, row, column);

            Assert.Equal(expected, actual);
        }
    }
}