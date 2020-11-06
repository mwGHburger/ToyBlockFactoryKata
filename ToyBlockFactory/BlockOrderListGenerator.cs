using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class BlockOrderListGenerator : IOrderListGenerator
    {
        private IConsoleIO _consoleIO;
        private List<IShape> _shapes;
        private List<IColour> _colours;
        public BlockOrderListGenerator(IConsoleIO consoleIO, List<IShape> shapes, List<IColour> colours)
        {
            _consoleIO = consoleIO;
            _shapes = shapes;
            _colours = colours;
        }
        public List<IBlockOrderItem> GetBlockOrderItemsDetails()
        {
            var blockOrderItems =  new List<IBlockOrderItem>();
            foreach(IShape shape in _shapes)
            {
                foreach(IColour colour in _colours)
                {
                    var orderQuantity = _consoleIO.GetInput($"Please input the number of {colour.Name} {shape.Name}: ");
                    blockOrderItems.Add(new BlockOrderItem(shape.Name, colour.Name, orderQuantity));
                }
            }
            return blockOrderItems;
        }
    }
}