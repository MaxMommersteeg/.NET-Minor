using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOefenen
{
    public class LeeftijdChange
    {
        public event LeeftijdChangedEventHandler LeeftijdChanged;
        public string Naam { get; internal set; }
        public int Leeftijd { get; internal set; }

        public LeeftijdChange(string naam, int leeftijd)
        {
            Naam = naam;
            Leeftijd = leeftijd;
        }

        public LeeftijdChange()
        {
            Naam = "Marco";
            Leeftijd = 0;
        }

        public void verjaar(int jaar)
        {
            OnLeeftijdChanged(new LeeftijdChangedEventArgs(jaar));
        }

        public void verjaar() 
        {
            verjaar(Leeftijd + 1);
        }


        protected virtual void OnLeeftijdChanged(LeeftijdChangedEventArgs leeftijdChangedEventArgs)
        {
            LeeftijdChangedEventHandler temp = LeeftijdChanged;
            temp?.Invoke(this, leeftijdChangedEventArgs);
        }
    }
}
