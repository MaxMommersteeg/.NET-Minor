using Minor.Dag09.EventOefening;
using System;

public class Werknemer : Persoon
{
    public decimal Salaris { get; private set; }

    public Werknemer(string naam, int leeftijd, decimal salaris) : base(naam, leeftijd)
    {
        Salaris = salaris;
    }

    protected override void OnLeeftijdChanged(LeeftijdChangedEventArgs e)
    {
        if (e.NieuweLeeftijd >= e.OudeLeeftijd)
        {
            for (int i = e.OudeLeeftijd; i < e.NieuweLeeftijd; i++)
            {
                Salaris = Math.Round(Salaris * 1.01M, 2);
            } 
        }
        else
        {
            for (int i = e.NieuweLeeftijd; i < e.OudeLeeftijd; i++)
            {
                Salaris = Math.Round(Salaris / 1.01M, 2);
            }

        }

        base.OnLeeftijdChanged(e);
    }
}