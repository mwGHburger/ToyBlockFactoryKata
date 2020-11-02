using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class Order : IOrder
    {
        public string CustomerName { get; }
        public string Address { get; }
        public string DueDate { get; }
        public string OrderNumber { get; }
        public List<BlockOrderItem> Blocks { get; }

        public Order(string customerName = "", string address = "", string dueDate = "", string orderNumber = "", List<BlockOrderItem> blocks = null)
        {
            CustomerName = customerName;
            Address = address;
            DueDate = dueDate;
            OrderNumber = orderNumber;
            Blocks = blocks;
        }

    }
}