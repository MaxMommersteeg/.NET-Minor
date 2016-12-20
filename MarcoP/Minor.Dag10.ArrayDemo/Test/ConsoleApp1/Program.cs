using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 2, 3, 5, 7 };
            List<string> names = new List<string> { "Jan", "Pier", "Tjores", "Corneel" };

            PrintList(numbers);
            PrintList<string>(names);

        }

        private static void PrintList<T>(List<T> items)
           // where T : struct
        {
            foreach (T item in items)
            {
                Console.Write(item + " - ");
            }
            Console.WriteLine();
        }

        private static void PrintList(List<int> items)
        {
            Console.WriteLine("{ 2, 3, 5, 7 };");
        }
    }
}
