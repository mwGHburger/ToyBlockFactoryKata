namespace ToyBlockFactory
{
    public interface IBlockOrderItem
    {
        string Shape { get; }
        string Colour { get; }
        int OrderQuantity { get; }
    }
}