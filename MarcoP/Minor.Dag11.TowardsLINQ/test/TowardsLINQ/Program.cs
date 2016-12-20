using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowardsLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19 };
            PrintList(primes);

            int threshold = 12;
            List<int> bigPrimes = primes.FindAll(n =>  n >= threshold);
            PrintList(bigPrimes);


            IEnumerable<int> squaresOfBigPrimes = bigPrimes.Select((int n) => n * n);
            PrintList(squaresOfBigPrimes);

            //IEnumerable<int> SoBP = primes.FindAll(IsLarge).Select(Square);
            //PrintList(SoBP);

            IEnumerable<int> SoBP = primes.Where(n => n >= threshold)
                                          .Select(n => n * n);

            IEnumerable<int> SoBP3 = from n in primes
                                     where n >= threshold
                                     select n * n;

        }





        private static void PrintList(IEnumerable<int> primes)
        {
            foreach (int item in primes)
            {
                Console.Write(item + " - ");
            }
            Console.WriteLine();
        }

    }
}
