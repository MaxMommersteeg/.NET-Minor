using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag38.HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Hello, World {i+1}");
                Thread.Sleep(500);
            }
        }
    }
}
