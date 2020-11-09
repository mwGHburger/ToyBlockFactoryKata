namespace ToyBlockFactory
{
    public class InvoiceFieldData : IFieldData
    {
        public string DetermineTableFieldData(IOrder order, string row, string column)
        {
            var fieldData = order.Blocks.Find(block => 
                block.Colour.Equals(column) && 
                block.Shape.Equals(row)
            ).OrderQuantity;
            
            var stringifiedQuantity = fieldData.Equals(0) ? "-" : $"{fieldData}";
            return stringifiedQuantity;
        }
    }
}