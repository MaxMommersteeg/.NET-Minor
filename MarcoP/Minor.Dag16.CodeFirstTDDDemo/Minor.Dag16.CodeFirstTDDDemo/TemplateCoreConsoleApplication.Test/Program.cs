using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateCoreConsoleApplication.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NaaktslakkenContext())
            {
                foreach (var item in context.Naaktslakken)
                {
                    Console.WriteLine(item.Soortnaam);
                }
            }
            Console.WriteLine("Done");
        }
    }
}
