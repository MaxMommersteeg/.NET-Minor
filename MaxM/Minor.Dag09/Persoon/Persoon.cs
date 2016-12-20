using PersoonOefening;

namespace Persoon
{
    public class Persoon
    {
        public event LeeftijdChangedEventHandler LeeftijdChanged;

        private int _leeftijd;
        public int Leeftijd { get { return _leeftijd; }
            set {
                    OnLeeftijdChanged(new LeeftijdChangedEventArgs(value, _leeftijd, Naam));
                    _leeftijd = value;
            }
        } 

        public string Naam { get; set; }

        public Persoon(int leeftijd, string naam)
        {
            _leeftijd = leeftijd;
            Naam = naam;
        }

        public void Verjaar(int nieuweLeeftijd)
        {
            Leeftijd = nieuweLeeftijd;
        }

        protected virtual void OnLeeftijdChanged(LeeftijdChangedEventArgs leeftijdChangedEventArgs)
        {
            LeeftijdChangedEventHandler temp = LeeftijdChanged; // Thread safety
            temp?.Invoke(this, leeftijdChangedEventArgs);
        }
    }
}
