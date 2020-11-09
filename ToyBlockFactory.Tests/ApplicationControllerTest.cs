using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class ApplicationControllerTest
    {
        [Fact]
        public void HandleSingleOrder_ShouldGetCustomerInformation_And_GenerateReports()
        {
            var mockOrderTaker = new Mock<IOrderTaker>();
            var mockReportGenerator = new Mock<IReportGenerator>();
            var applicationController = new ApplicationController(mockOrderTaker.Object, mockReportGenerator.Object);

            applicationController.HandleSingleOrder();

            mockOrderTaker.Verify(x => x.TakeSingleOrder());
            mockReportGenerator.Verify(x => x.GenerateReportsForSingleOrder(It.IsAny<IOrder>()));
        }
    }
}