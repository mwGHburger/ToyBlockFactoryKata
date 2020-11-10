using System.Collections.Generic;

namespace ToyBlockFactory
{
    public interface IOrder
    {
        string CustomerName { get; }
        string Address { get; }
        string DueDate { get; }
        string OrderNumber { get; }
        List<IBlockOrderItem> Blocks { get; }
    }
}