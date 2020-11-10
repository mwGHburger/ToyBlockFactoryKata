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
            var blocks = SetupBlocks();
            var mockOrder = new Mock<IOrder>();
            var cuttingListFieldData = new CuttingListFieldData();

            mockOrder.Setup(x => x.Blocks).Returns(blocks);

            var actual = cuttingListFieldData.DetermineTableFieldData(mockOrder.Object, row);

            Assert.Equal(expected, actual);
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