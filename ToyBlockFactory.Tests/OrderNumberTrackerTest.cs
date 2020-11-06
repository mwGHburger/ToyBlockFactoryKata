using Xunit;

namespace ToyBlockFactory.Tests
{
    public class OrderNumberTrackerTest
    {
        [Fact]
        public void GetNewOrderNumber_ShouldReturnNumberOrderNumberAsString()
        {
            var orderNumberTracker = new OrderNumberTracker();

            var actual = orderNumberTracker.GetNewOrderNumber();

            Assert.Equal("0001", actual);
        }
    }
}