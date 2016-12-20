using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventbusReceiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var dispatcher = new MyReciever())
            {
                Console.WriteLine("Server is listening...");
                Console.WriteLine("Press any key to quit");
                Console.ReadKey();
            }
        }
    }
}
