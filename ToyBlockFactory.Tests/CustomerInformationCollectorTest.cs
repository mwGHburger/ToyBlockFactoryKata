using System;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class CustomerInformationCollectorTest
    {
        [Fact]
        public void GetCustomerInformation_ShouldReturnCustomerInformationObject()
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            var customerInformationCollector = new CustomerInformationCollector(mockConsoleIO.Object);

            var actual = customerInformationCollector.GetCustomerInformation();

            Assert.IsType<CustomerInformationData>(actual);
        }

        [Fact]
        public void GetCustomerInformation_ShouldReturnBuyerInformationObject_HoldingInputData()
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            var customerInformationCollector = new CustomerInformationCollector(mockConsoleIO.Object);
            var name = "Mar Pearl";
            var address = "1 Bob Avenue, Aucklan";
            var dueDate = "19 Jan 2019";

            mockConsoleIO.Setup(x => x.GetInput("Please input your Name: ")).Returns(name);
            mockConsoleIO.Setup(x => x.GetInput("Please input your Address: ")).Returns(address);
            mockConsoleIO.Setup(x => x.GetInput("Please input your Due Date: ")).Returns(dueDate);

            var actualCustomerInformationDataObject = customerInformationCollector.GetCustomerInformation();

            Assert.Equal(name, actualCustomerInformationDataObject.Name);
            Assert.Equal(address, actualCustomerInformationDataObject.Address);
            Assert.Equal(dueDate, actualCustomerInformationDataObject.DueDate);

            mockConsoleIO.Verify(x => x.GetInput("Please input your Name: "), Times.Exactly(1));
            mockConsoleIO.Verify(x => x.GetInput("Please input your Address: "), Times.Exactly(1));
            mockConsoleIO.Verify(x => x.GetInput("Please input your Due Date: "), Times.Exactly(1));
        }
    }
}
