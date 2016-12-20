using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag09.DelegateDemo.NuEcht
{
    public class Lightbulb
    {
        public void Burn(object sender, SwitchedEventArgs e)
        {
            if (e.State)
                Console.WriteLine("lightbulb is ON");
            else
                Console.WriteLine("lightbulb is OFF");
        }
    }
}
