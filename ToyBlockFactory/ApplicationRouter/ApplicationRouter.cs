namespace ToyBlockFactory
{
    public class ApplicationRouter : IApplicationRouter
    {
        private IApplicationController _applicationController;
        private IStandardApplicationMessages _standardApplicationMessages;
        private IConsoleIO _consoleIO;
        private bool _isApplicationRunning = true;

        public ApplicationRouter(IApplicationController applicationController, IConsoleIO consoleIO, IStandardApplicationMessages standardApplicationMessages )
        {
            _applicationController = applicationController;
            _standardApplicationMessages = standardApplicationMessages;
            _consoleIO = consoleIO;
        }

        public void Run()
        {
            _consoleIO.Write(_standardApplicationMessages.Welcome());
            while(_isApplicationRunning)
            {
                var input = _consoleIO.GetInput(_standardApplicationMessages.Router());
                switch(input)
                {
                    case "1":
                        _applicationController.HandleSingleOrder();
                        break;
                    case "q":
                        _isApplicationRunning = false;
                        break;
                }
            }
            _consoleIO.Write(_standardApplicationMessages.EndApplication());
        }
    }
}