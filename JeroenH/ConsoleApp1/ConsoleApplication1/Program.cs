using InfoSupport.Threading.MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static int r1 { get; set; }
        public static int r2 { get; set; }
        public static int r3 { get; set; }

        static void Main(string[] args)
        {
            int i1 = 5;
            int i2 = 2;
            int i3 = 3;

            var startTime = DateTime.Now.Second;
            var slowMath = new SlowMath();

            Task<int>[] tasks = new Task<int>[]
            {
                Task<int>.Factory.StartNew(() => r1 = slowMath.SquareAsync(i1).Result),
                Task<int>.Factory.StartNew(() => r2 = slowMath.SquareAsync(i2).Result),
                Task<int>.Factory.StartNew(() => r3 = slowMath.SquareAsync(i3).Result),
            };
            Task.WaitAll(tasks);
            var endTime = DateTime.Now.Second;

            var difference = endTime - startTime;
            Console.WriteLine($"{r1 + r2 + r3} {difference}");
        }
    }
}
