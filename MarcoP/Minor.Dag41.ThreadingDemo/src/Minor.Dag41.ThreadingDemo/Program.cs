using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag41.ThreadingDemo
{
    public class Program
    {
        private static object consoleLock = new object();
        private static EventWaitHandle vlaggetje = new AutoResetEvent(false);
        private static int i = 0; 

        public static void ZetKruisjes(object colorObj)
        {
            var kruisje = "X";
            var colour = (ConsoleColor)colorObj;

            for (i = 0; i < 1000; Interlocked.Increment(ref i))
            {
                lock (consoleLock)
                {
                    Console.ForegroundColor = colour;
                    Console.Write($"{kruisje}{i}");
                }
                if (i == 200)
                {
                    vlaggetje.WaitOne();
                }
            }
        }

        public static void Main(string[] args)
        {
            Thread blue = new Thread(ZetKruisjes);
            Thread red = new Thread(ZetKruisjes);
            blue.IsBackground = true;

            blue.Start(ConsoleColor.Blue);
            red.Start(ConsoleColor.Red);

            var kruisje = "X";
            var colour = ConsoleColor.Green;

            for (i = 0; i < 1000; Interlocked.Increment(ref i))
            {
                lock (consoleLock)
                {
                    Console.ForegroundColor = colour;
                    Console.Write($"{kruisje}{i}");
                }
                if (i == 500)
                {
                    vlaggetje.Set();
                }
                if (i == 800)
                {
                    vlaggetje.Set();
                }

            }
        }
    }
}
