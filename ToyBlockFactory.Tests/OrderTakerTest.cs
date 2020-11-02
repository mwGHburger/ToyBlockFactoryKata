using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class OrderTakerTest
    {
        Mock<IBuyerInformationCollector> mockBuyerInformationCollector = new Mock<IBuyerInformationCollector>();
        Mock<IOrderListGenerator> mockBlockOrderListGenerator = new Mock<IOrderListGenerator>();
        Mock<IOrderNumberTracker> mockOrderNumberTracker = new Mock<IOrderNumberTracker>();

        [Fact]
        public void TakeSingleOrderShouldReturnAnIOrderTypeObject()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);
            
            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData());

            var actual = orderTaker.TakeSingleOrder();

            Assert.IsType<Order>(actual);
        }

        [Fact]
        public void TakeSingleOrderShouldCollectBuyerInformation()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData());

            orderTaker.TakeSingleOrder();

            mockBuyerInformationCollector.Verify(x => x.GetBuyerInformation(), Times.Exactly(1));
        }

        [Fact]
        public void TakeSingleOrderShouldCollectBlockOrderQuantities()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData());

            orderTaker.TakeSingleOrder();

            mockBlockOrderListGenerator.Verify(x => x.GetBlockOrderItemsDetails(), Times.Exactly(1));
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithCustomerName()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData(name: "Mark Pearl"));

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("Mark Pearl", actualOrder.CustomerName);
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithAddress()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData(address: "1 Bob Avenue, Auckland"));

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("1 Bob Avenue, Auckland", actualOrder.Address);
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithDueDate()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData(dueDate: "19 Jan 2019"));

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("19 Jan 2019", actualOrder.DueDate);
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithOrderNumber()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData());
            mockOrderNumberTracker.Setup(x => x.GetNewOrderNumber()).Returns("0001");

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("0001", actualOrder.OrderNumber);

            mockOrderNumberTracker.Verify(x => x.GetNewOrderNumber());
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithListOfBlockItems()
        {
            var orderTaker = new OrderTaker(mockBuyerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockBuyerInformationCollector.Setup(x => x.GetBuyerInformation()).Returns(new BuyerInformationData());
            mockBlockOrderListGenerator.Setup(x => x.GetBlockOrderItemsDetails()).Returns(new List<BlockOrderItem>());

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.IsType<List<BlockOrderItem>>(actualOrder.Blocks);
        }
    }
}