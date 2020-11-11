using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class BlockOrderListGeneratorTest
    {
        [Fact]
        public void GetBlockOrderItemsDetails_ShouldReturnTypeListOfBlockOrderItems()
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            var blockListGenerator = new BlockOrderListGenerator(mockConsoleIO.Object, TestHelper.SetupShapes(), TestHelper.SetupColours());
            
            var actualBlockOrderItemsList = blockListGenerator.GetBlockOrderItemsDetails();

            Assert.IsType<List<IBlockOrderItem>>(actualBlockOrderItemsList);
        }

        [Theory]
        [InlineData("Red", "Square", "1", 1)]
        [InlineData("Blue", "Triangle", "4", 4)]
        [InlineData("Yellow", "Circle", "2", 2)]
        public void GetBlockOrderItemsDetails_ShouldReturnAListOfBlockOrderItems(string colour, string shape, string actualQuantity, int expectedQuantity)
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            
            var blockListGenerator = new BlockOrderListGenerator(mockConsoleIO.Object, TestHelper.SetupShapes(), TestHelper.SetupColours());

            mockConsoleIO.Setup(x => x.GetInput($"Please input the number of {colour} {shape}: ")).Returns(actualQuantity);
            
            var blockOrderItemsList = blockListGenerator.GetBlockOrderItemsDetails();
            var blockOrderItem1 = blockOrderItemsList.Find( x => x.Shape.Equals(shape) && x.Colour.Equals(colour));

            Assert.Equal(shape, blockOrderItem1.Shape);
            Assert.Equal(colour, blockOrderItem1.Colour);
            Assert.Equal(expectedQuantity, blockOrderItem1.OrderQuantity);

            mockConsoleIO.Verify(x => x.GetInput($"Please input the number of {colour} {shape}: "));
        }
    }
}