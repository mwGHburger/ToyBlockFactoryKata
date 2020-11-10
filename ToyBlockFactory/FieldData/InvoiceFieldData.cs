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
            
            var stringifiedFieldData = FormatFieldData(fieldData);
            return stringifiedFieldData;
        }
        private string FormatFieldData(int fieldData)
        {
            return fieldData.Equals(0) ? "-" : $"{fieldData}";
        }
    }
}