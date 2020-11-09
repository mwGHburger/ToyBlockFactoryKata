using System.Reflection.Emit;
namespace ToyBlockFactory
{
    public class StandardApplicationMessages : IStandardApplicationMessages
    {
        public string Welcome()
        {
            return "Welcome to the Toy Block Factory!";
        }

        public string EndApplication()
        {
            return "Ending Application...";
        }

        public string Router()
        {
            return "Choose a function\n" +
            "1 - Make Single Order\n" +
            "q - To Quit Application\n";
        }
    }
}