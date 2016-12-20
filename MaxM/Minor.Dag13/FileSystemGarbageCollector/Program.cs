using System;

namespace FileSystemGarbageCollector
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new HomeController(new ConsoleReader(), new ConsoleWriter()).RequestPath();
            Console.ReadLine();
        }
    }
}
