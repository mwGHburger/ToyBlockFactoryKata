using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class StandardReportMessagesTest
    {
        [Theory]
        [InlineData("Your Invoice Report has been generated:\n\n", "Invoice Report")]
        [InlineData("Your Cutting List Report has been generated:\n\n", "Cutting List Report")]
        [InlineData("Your Painting Report has been generated:\n\n", "Painting Report")]
        public void GenerateReportConfirmation_ShouldReturnStringConfirmingReportGenerated(string expected, string reportType)
        {
            var standardReportMessages = new StandardReportMessages();

            var actual = standardReportMessages.GenerateReportConfirmation(reportType);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DisplayCustomerDetails_ShouldStringWithCustomerDetails()
        {
            var mockOrder = new Mock<IOrder>();
            var standardReportMessages = new StandardReportMessages();

            mockOrder.Setup(x => x.CustomerName).Returns("Mark Pearl");
            mockOrder.Setup(x => x.Address).Returns("1 Bob Avenue, Auckland");
            mockOrder.Setup(x => x.DueDate).Returns("19 Jan 2019");
            mockOrder.Setup(x => x.OrderNumber).Returns("0001");

            var actual = standardReportMessages.DisplayCustomerDetails(mockOrder.Object);

            Assert.Equal("Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n\n", actual);
        }
    }
}