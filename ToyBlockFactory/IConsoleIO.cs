namespace ToyBlockFactory
{
    public interface IConsoleIO
    {
        string GetInput(string prompt);
        void Write(string displayText);
    }
}