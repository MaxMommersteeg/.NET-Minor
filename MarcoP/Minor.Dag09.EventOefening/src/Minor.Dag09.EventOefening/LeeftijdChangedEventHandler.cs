namespace Minor.Dag09.EventOefening
{
    public delegate void LeeftijdChangedEventHandler(object sender, LeeftijdChangedEventArgs e);

    public class LeeftijdChangedEventArgs
    {
        public int NieuweLeeftijd { get; }
        public int OudeLeeftijd { get; }

        public LeeftijdChangedEventArgs(int oud, int nieuw)
        {
            OudeLeeftijd = oud;
            NieuweLeeftijd = nieuw;
        }

    }
}