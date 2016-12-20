using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag09.DelegateDemo.NuEcht
{
    public class Electrician
    {
        public static void Main(string[] args)
        {
            Lightbulb peertje = new Lightbulb();
            Tubelight tl = new Tubelight();
            Lightbulb peertje2 = new Lightbulb();
            Switch schakelaar = new Switch();

            schakelaar.Switched += peertje.Burn;
            schakelaar.Switched += tl.Ignite;
            schakelaar.Switched += peertje2.Burn;

            Console.WriteLine("Let's turn ON the lights..");
            schakelaar.SwitchMe();
            Console.WriteLine();

            schakelaar.Switched -= peertje2.Burn;

            Console.WriteLine("Let's turn OFF the lights..");
            schakelaar.SwitchMe();
            Console.WriteLine();

        }
    }
}
