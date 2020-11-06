using System.Collections.Generic;
using Moq;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class OrderTakerTest
    {
        Mock<ICustomerInformationCollector> mockCustomerInformationCollector = new Mock<ICustomerInformationCollector>();
        Mock<IOrderListGenerator> mockBlockOrderListGenerator = new Mock<IOrderListGenerator>();
        Mock<IOrderNumberTracker> mockOrderNumberTracker = new Mock<IOrderNumberTracker>();

        [Fact]
        public void TakeSingleOrderShouldReturnAnIOrderTypeObject()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);
            
            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData());

            var actual = orderTaker.TakeSingleOrder();

            Assert.IsType<Order>(actual);
        }

        [Fact]
        public void TakeSingleOrderShouldCollectBuyerInformation()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData());

            orderTaker.TakeSingleOrder();

            mockCustomerInformationCollector.Verify(x => x.GetCustomerInformation(), Times.Exactly(1));
        }

        [Fact]
        public void TakeSingleOrderShouldCollectBlockOrderQuantities()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData());

            orderTaker.TakeSingleOrder();

            mockBlockOrderListGenerator.Verify(x => x.GetBlockOrderItemsDetails(), Times.Exactly(1));
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithCustomerName()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData(name: "Mark Pearl"));

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("Mark Pearl", actualOrder.CustomerName);
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithAddress()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData(address: "1 Bob Avenue, Auckland"));

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("1 Bob Avenue, Auckland", actualOrder.Address);
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithDueDate()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData(dueDate: "19 Jan 2019"));

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("19 Jan 2019", actualOrder.DueDate);
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithOrderNumber()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData());
            mockOrderNumberTracker.Setup(x => x.GetNewOrderNumber()).Returns("0001");

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.Equal("0001", actualOrder.OrderNumber);

            mockOrderNumberTracker.Verify(x => x.GetNewOrderNumber());
        }

        [Fact]
        public void TakeSingleOrderShouldReturnAnOrderObjectWithListOfBlockItems()
        {
            var orderTaker = new OrderTaker(mockCustomerInformationCollector.Object, mockBlockOrderListGenerator.Object, mockOrderNumberTracker.Object);

            mockCustomerInformationCollector.Setup(x => x.GetCustomerInformation()).Returns(new CustomerInformationData());
            mockBlockOrderListGenerator.Setup(x => x.GetBlockOrderItemsDetails()).Returns(new List<IBlockOrderItem>());

            var actualOrder = orderTaker.TakeSingleOrder();

            Assert.IsType<List<IBlockOrderItem>>(actualOrder.Blocks);
        }
    }
}