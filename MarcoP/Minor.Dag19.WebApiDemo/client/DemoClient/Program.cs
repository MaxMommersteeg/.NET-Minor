using DemoClient.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISlakkenService agent = new SlakkenService();
            agent.BaseUri = new Uri("http://localhost:12364/");
            var list = agent.GetAll();
            foreach (var item in list)
            {

                Console.WriteLine(item.Naam);
            }
        }
    }
}
