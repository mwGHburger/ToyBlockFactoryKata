using System;
namespace ToyBlockFactory
{
    public class BlockOrderItem
    {
        public string Shape { get; }
        public string Colour { get; }
        public int OrderQuantity { get; }

        public BlockOrderItem(string shape, string colour, string orderQuantity)
        {
            Shape = shape;
            Colour = colour;
            OrderQuantity = Convert.ToInt32(orderQuantity);
        }
    }
}