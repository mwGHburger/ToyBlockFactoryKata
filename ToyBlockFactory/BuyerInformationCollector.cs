namespace ToyBlockFactory
{
    public class BuyerInformationCollector : IBuyerInformationCollector
    {
        private IConsoleIO _consoleIO;
        public BuyerInformationCollector(IConsoleIO consoleIO)
        {
            _consoleIO = consoleIO;
        }

        public BuyerInformationData GetBuyerInformation()
        {
            var name = _consoleIO.GetInput(AskForBuyerInformation("Name"));
            var address = _consoleIO.GetInput(AskForBuyerInformation("Address"));
            var dueDue = _consoleIO.GetInput(AskForBuyerInformation("Due Date"));
            return new BuyerInformationData(name, address, dueDue);
        }

        private string AskForBuyerInformation(string data)
        {
            return $"Please input your {data}: ";
        }
    }
}