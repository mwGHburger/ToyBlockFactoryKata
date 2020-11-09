namespace ToyBlockFactory
{
    public class CuttingListFieldData : IFieldData
    {
        public string DetermineTableFieldData(IOrder order, string row, string column = "")
        {
            var fieldData = 0;
            var blocks = order.Blocks.FindAll(block => block.Shape.Equals(row));
            blocks.ForEach(block => fieldData += block.OrderQuantity);
            
            var stringifiedQuantity = fieldData.Equals(0) ? "-" : $"{fieldData}";
            return stringifiedQuantity;
        }
    }
    
}