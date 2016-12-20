using InfoSupport.Threading.MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPLdemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parallel.For(0, 100, (int i) =>
             {
                 var tid = Thread.CurrentThread.ManagedThreadId;
                 Console.Write($"{i}({tid}) ");
             });
            int kw = DoWork().Result;
            Console.WriteLine("Done!!");
            Console.ReadKey();
        }

        public static async Task<int> DoWork()
        {
            SlowMath math = new SlowMath();
            int kwadraat = await math.SquareAsync(5);
            Console.WriteLine(kwadraat);

            return kwadraat;
        }
    }
}
