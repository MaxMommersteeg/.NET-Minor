using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaExpressionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> primes = new List<int> { 2, 3, 5};

            int threshold = 12;
            var bigPrimes = primes.FindAll(n => n >= threshold)
                                  .Select(n => n * n);
        }
    }
}
