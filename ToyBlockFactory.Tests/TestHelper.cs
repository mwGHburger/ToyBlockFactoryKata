using System.Collections.Generic;

namespace ToyBlockFactory.Tests
{
    public static class TestHelper
    {
        public static List<IColour> SetupColours()
        {
            return new List<IColour>()
            {
                new Red(),
                new Blue(),
                new Yellow()
            };
        }

        public static List<IShape> SetupShapes()
        {
            return new List<IShape>()
            {
                new Square(),
                new Triangle(),
                new Circle()
            };
        }
        public static List<IBlockOrderItem> SetupBlocks()
        {
            return new List<IBlockOrderItem>()
            {
                new BlockOrderItem("Square", "Red", 1),
                new BlockOrderItem("Triangle", "Red", 0),
                new BlockOrderItem("Circle", "Red", 0),
                new BlockOrderItem("Square", "Blue", 0),
                new BlockOrderItem("Triangle", "Blue", 2),
                new BlockOrderItem("Circle", "Blue", 1),
                new BlockOrderItem("Square", "Yellow", 1),
                new BlockOrderItem("Triangle", "Yellow", 0),
                new BlockOrderItem("Circle", "Yellow", 2)
            };
        }
    }
}