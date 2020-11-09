namespace ToyBlockFactory
{
    public interface IFieldData
    {
        string DetermineTableFieldData(IOrder order, string row, string column);
    }
}