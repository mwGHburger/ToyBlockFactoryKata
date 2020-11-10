namespace ToyBlockFactory
{
    public class CuttingListFieldData : IFieldData
    {
        public string DetermineTableFieldData(IOrder order, string row, string column = "")
        {
            var fieldData = 0;
            var blocks = order.Blocks.FindAll(block => block.Shape.Equals(row));
            blocks.ForEach(block => fieldData += block.OrderQuantity);
            
            var stringifiedFieldData = FormatFieldData(fieldData);
            return stringifiedFieldData;
        }

        private string FormatFieldData(int fieldData)
        {
            return fieldData.Equals(0) ? "-" : $"{fieldData}";
        }
    }
    
}