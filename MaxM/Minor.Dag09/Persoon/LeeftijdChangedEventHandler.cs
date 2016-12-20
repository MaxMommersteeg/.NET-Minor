using System;

namespace PersoonOefening
{
    public delegate void LeeftijdChangedEventHandler(object sender, LeeftijdChangedEventArgs leeftijdChangedEventArgs);

    public class LeeftijdChangedEventArgs : EventArgs
    {
        public int NieuweLeeftijd { get; }
        public int OudeLeeftijd { get; }
        public string Naam { get; }

        public LeeftijdChangedEventArgs(int nieuweLeeftijd, int oudeLeeftijd, string naam)
        {
            NieuweLeeftijd = nieuweLeeftijd;
            OudeLeeftijd = oudeLeeftijd;
            Naam = naam;
        }
    }
}
