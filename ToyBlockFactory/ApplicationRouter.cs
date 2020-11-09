namespace ToyBlockFactory
{
    public class ApplicationRouter
    {
        private IApplicationController _applicationController;
        private IConsoleIO _consoleIO;
        private bool _isApplicationRunning = true;

        public ApplicationRouter(IApplicationController applicationController, IConsoleIO consoleIO)
        {
            _applicationController = applicationController;
            _consoleIO = consoleIO;
        }

        public void Run()
        {
            var prompt = 
            "Choose a function\n" +
            "1 - Make Single Order\n" +
            "q - To Quit Application";
            while(_isApplicationRunning)
            {
                var input = _consoleIO.GetInput(prompt);
                switch(input)
                {
                    case "1":
                        _applicationController.HandleSingleOrder();
                        break;
                    case "q":
                        _isApplicationRunning = false;
                        return;
                }
            }
        }
    }
}