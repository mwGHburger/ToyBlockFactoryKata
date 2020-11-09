using System;

namespace ToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = ClassFactory.CreateApplication();
            application.Run();
        }
    }
}
