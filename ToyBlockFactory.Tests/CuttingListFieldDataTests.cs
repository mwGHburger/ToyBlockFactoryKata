using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class CuttingListFieldDataTest
    {
        [Theory]
        [InlineData("Square", "2")]
        [InlineData("Circle", "3")]
        public void DetermineTableFieldData_ShouldReturnStringData(string row, string expected)
        {
            var blocks = TestHelper.SetupBlocks();
            var mockOrder = new Mock<IOrder>();
            var cuttingListFieldData = new CuttingListFieldData();

            mockOrder.Setup(x => x.Blocks).Returns(blocks);

            var actual = cuttingListFieldData.DetermineTableFieldData(mockOrder.Object, row);

            Assert.Equal(expected, actual);
        }
    }
    
}