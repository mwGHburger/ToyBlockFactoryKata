namespace ToyBlockFactory
{
    public class CustomerInformationData
    {
        public string Name { get; }
        public string Address { get; }
        public string DueDate { get; }

        public CustomerInformationData(string name = "", string address = "", string dueDate = "")
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
        }
    }
}