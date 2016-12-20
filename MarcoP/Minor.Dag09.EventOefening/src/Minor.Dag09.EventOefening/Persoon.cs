using System;
using System.Threading;
using Minor.Dag09.EventOefening;

public class Persoon
{
    private int _leeftijd;
    public string Naam { get; set; }
    public int Leeftijd
    {
        get { return _leeftijd; }
        set
        {
            int oud = _leeftijd;
            _leeftijd = value;
            OnLeeftijdChanged(new LeeftijdChangedEventArgs(oud, _leeftijd));
        }
    }

    public event LeeftijdChangedEventHandler LeeftijdChanged;

    public Persoon(string naam, int leeftijd)
    {
        Naam = naam;
        Leeftijd = leeftijd;
    }

    public void Verjaar()
    {
        Leeftijd++;
    }

    protected virtual void OnLeeftijdChanged(LeeftijdChangedEventArgs e)
    {
        Thread.Sleep(100);
        LeeftijdChangedEventHandler temp = LeeftijdChanged;
        temp?.Invoke(this, e);
    }
}