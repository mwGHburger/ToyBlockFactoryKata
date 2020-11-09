namespace ToyBlockFactory
{
    public interface IFieldData
    {
        string DetermineTableFieldData(string row, string column,IOrder order);
    }
}