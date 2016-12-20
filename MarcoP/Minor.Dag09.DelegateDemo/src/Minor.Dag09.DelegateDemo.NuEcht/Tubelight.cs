using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag09.DelegateDemo.NuEcht
{
    public class Tubelight
    {
        public void Ignite(object sender, SwitchedEventArgs e)
        {
            if (e.State)
                Console.WriteLine("Tubelight is ON");
            else
                Console.WriteLine("Tubelight is OFF");
        }
    }
}
