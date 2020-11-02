using System;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class BuyerInformationCollectorTest
    {
        [Fact]
        public void GetBuyerInformation_ShouldReturnBuyerInformationObject()
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            var buyerInformationCollector = new BuyerInformationCollector(mockConsoleIO.Object);

            var actual = buyerInformationCollector.GetBuyerInformation();

            Assert.IsType<BuyerInformationData>(actual);
        }

        [Fact]
        public void GetBuyerInformation_ShouldReturnBuyerInformationObject_HoldingInputData()
        {
            var mockConsoleIO = new Mock<IConsoleIO>();
            var buyerInformationCollector = new BuyerInformationCollector(mockConsoleIO.Object);
            var name = "Mar Pearl";
            var address = "1 Bob Avenue, Aucklan";
            var dueDate = "19 Jan 2019";

            mockConsoleIO.Setup(x => x.GetInput("Please input your Name: ")).Returns(name);
            mockConsoleIO.Setup(x => x.GetInput("Please input your Address: ")).Returns(address);
            mockConsoleIO.Setup(x => x.GetInput("Please input your Due Date: ")).Returns(dueDate);

            var actualBuyerInformationDataObject = buyerInformationCollector.GetBuyerInformation();

            Assert.Equal(name, actualBuyerInformationDataObject.Name);
            Assert.Equal(address, actualBuyerInformationDataObject.Address);
            Assert.Equal(dueDate, actualBuyerInformationDataObject.DueDate);

            mockConsoleIO.Verify(x => x.GetInput("Please input your Name: "), Times.Exactly(1));
            mockConsoleIO.Verify(x => x.GetInput("Please input your Address: "), Times.Exactly(1));
            mockConsoleIO.Verify(x => x.GetInput("Please input your Due Date: "), Times.Exactly(1));
        }
    }
}
