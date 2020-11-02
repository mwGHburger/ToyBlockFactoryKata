using System.Collections.Generic;

namespace ToyBlockFactory
{
    public interface IOrderListGenerator
    {
         List<BlockOrderItem> GetBlockOrderItemsDetails();
    }
}