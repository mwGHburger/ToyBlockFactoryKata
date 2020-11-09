using System;

namespace ToyBlockFactory
{
    public class ConsoleIO : IConsoleIO
    {
        public string GetInput(string prompt)
        {
            Write(prompt);
            return System.Console.ReadLine();
        }

        public void Write(string displayText)
        {
            System.Console.WriteLine(displayText);
        }
    }
}