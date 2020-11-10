namespace ToyBlockFactory
{
    public class CustomerInformationCollector : ICustomerInformationCollector
    {
        private IConsoleIO _consoleIO;
        public CustomerInformationCollector(IConsoleIO consoleIO)
        {
            _consoleIO = consoleIO;
        }

        public CustomerInformationData GetCustomerInformation()
        {
            var name = _consoleIO.GetInput(AskForCustomerInformation("Name"));
            var address = _consoleIO.GetInput(AskForCustomerInformation("Address"));
            var dueDue = _consoleIO.GetInput(AskForCustomerInformation("Due Date"));
            return new CustomerInformationData(name, address, dueDue);
        }

        private string AskForCustomerInformation(string data)
        {
            return $"Please input your {data}: ";
        }
    }
}