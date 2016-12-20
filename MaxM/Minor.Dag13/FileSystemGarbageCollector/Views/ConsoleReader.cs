using System;

namespace FileSystemGarbageCollector
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReceiveInput()
        {
            return Console.ReadLine();
        }
    }
}
