using System.Collections.Generic;

namespace ToyBlockFactory
{
    public interface IOrderListGenerator
    {
         List<IBlockOrderItem> GetBlockOrderItemsDetails();
    }
}