using Xunit;

namespace ToyBlockFactory.Tests
{
    public class OrderNumberTrackerTest
    {
        [Fact]
        public void GetNewOrderNumberShouldReturnNumberOrderNumberAsString()
        {
            var orderNumberTracker = new OrderNumberTracker();

            var actual = orderNumberTracker.GetNewOrderNumber();

            Assert.Equal("0001", actual);
        }
    }
}