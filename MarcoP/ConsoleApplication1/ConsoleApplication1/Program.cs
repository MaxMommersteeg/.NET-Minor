using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 3; i < 100; i++)
            {
                var machten3 = new List<int>();
                FillList(machten3, i);
                var machten6 = new List<int>();
                FillList(machten6, 2*i);
                var machten9 = new List<int>();
                FillList(machten9, 3*i);

                for (int m3 = 1; m3 < machten3.Count; m3++)
                {
                    for (int m6 = 0; m6 < machten6.Count; m6++)
                    {
                        int sum = machten3[m3] + machten6[m6];
                        //Console.WriteLine("3^" + (m3+1) + " + 6^" + (m6+1) + " = " + sum);
                        if (machten9.Contains(sum))
                        {
                            Console.WriteLine("i = " + i);
                            Console.WriteLine($"{i}^{m3+1} + {2 * i}^{m6+1} = {3 * i}^{machten9.IndexOf(sum)+1}");
                            Console.WriteLine(machten3[m3] + " + " + machten6[m6] + " = " + sum);
                        }
                    }
                } 
            }

        }

        private static void FillList(List<int> p3, int factor)
        {
            int p = 1;
            while (p <= int.MaxValue / factor)
            {
                p *= factor;
                p3.Add(p);
            }
        }
    }
}
