namespace ToyBlockFactory
{
    public class BuyerInformationData
    {
        public string Name { get; }
        public string Address { get; }
        public string DueDate { get; }

        public BuyerInformationData(string name = "", string address = "", string dueDate = "")
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
        }
    }
}