using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOefenen
{
    public delegate void LeeftijdChangedEventHandler(
        object sender, 
        LeeftijdChangedEventArgs e
        );

    public class LeeftijdChangedEventArgs : EventArgs
    {
        public readonly int Leeftijd;

        public LeeftijdChangedEventArgs(int leeftijd)
        {
            Leeftijd = leeftijd;
        }
    }
}
