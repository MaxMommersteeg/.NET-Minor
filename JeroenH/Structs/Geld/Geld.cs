using System;
using System.Collections.Generic;
using System.Diagnostics;

public struct Geld
{
    private decimal Bedrag;
    private Valuta Muntsoort;
    private IDictionary<Valuta, decimal> Omreken;
    private Valuta ValutaLinks;

    public Geld(decimal bedrag) : this(Valuta.Euro, bedrag)
    {
        System.GC.Collect();

    }

    public Geld(Valuta valuta, decimal bedrag)
    {
        Muntsoort = valuta;
        Bedrag = bedrag;
        Omreken = new Dictionary<Valuta, decimal>();
        Omreken[Valuta.Euro] = 2.20371M;
        Omreken[Valuta.Dukaat] = 5.1M;
        Omreken[Valuta.Florijn] = 1.0M;
        ValutaLinks = Valuta.Euro;

    }

    public static Geld operator *(Geld g, Geld m)
    {
        m = g.MaakGeldValutaGelijk(g, m);

        decimal BedragG = g.ParseBedragToDecimal(g);
        decimal BedragM = m.ParseBedragToDecimal(m);

        return new Geld(g.ValutaLinks, BedragG * BedragM);
    }

    public static bool operator ==(Geld g, Geld m)
    {
        m = g.MaakGeldValutaGelijk(g, m);

        decimal BedragG = g.ParseBedragToDecimal(g);
        decimal BedragM = m.ParseBedragToDecimal(m);

        return BedragG == BedragM;
    }

    public static bool operator !=(Geld g, Geld m)
    {
        m = g.MaakGeldValutaGelijk(g, m);

        decimal BedragG = g.ParseBedragToDecimal(g);
        decimal BedragM = m.ParseBedragToDecimal(m);

        return BedragG != BedragM;
    }

    public static Geld operator *(Geld g, decimal m)
    {

        decimal BedragG = g.ParseBedragToDecimal(g);

        return new Geld(g.ValutaLinks, BedragG * m);
    }

    private Geld MaakGeldValutaGelijk(Geld g, Geld m)
    {

        switch (g.ToString().Substring(0, 1))
        {
            case "E":
                m.ConvertTo(Valuta.Euro);
                ValutaLinks = Valuta.Euro;
                break;
            case "G":
                m.ConvertTo(Valuta.Gulden);
                ValutaLinks = Valuta.Gulden;

                break;
            case "D":
                m.ConvertTo(Valuta.Dukaat);
                ValutaLinks = Valuta.Dukaat;

                break;
            case "F":
                m.ConvertTo(Valuta.Florijn);
                ValutaLinks = Valuta.Florijn;

                break;
        }

        return m;
    }

    public static Geld operator +(Geld g, Geld m)
    {
        m = g.MaakGeldValutaGelijk(g, m);
        

        decimal BedragG = g.ParseBedragToDecimal(g);
        decimal BedragM = m.ParseBedragToDecimal(m);

        return new Geld(g.ValutaLinks, BedragG+BedragM);
    }

    private decimal ParseBedragToDecimal(Geld geld)
    {
        string BedragString = geld.ToString().Split(' ')[1];
        decimal ParseBedragDecimal;
        if (!decimal.TryParse(BedragString, out ParseBedragDecimal))
        {
            throw new ArgumentException("Dit is geen geld");
        }
        return ParseBedragDecimal;
    }

    public override string ToString()
    {
        return Muntsoort.ToString() + " " + string.Format("{0:N2}", Bedrag);
    }

    public void ConvertTo(Valuta muntsoort)
    {

        ConvertToGulden();
        ConvertFromGulden(muntsoort);

        Muntsoort = muntsoort;

    }

    private void ConvertToGulden()
    {
        switch (Muntsoort)
        {
            case Valuta.Euro:
                Bedrag *= Omreken[Valuta.Euro];
                break;
            case Valuta.Gulden:

                break;
            case Valuta.Dukaat:
                Bedrag *= Omreken[Valuta.Dukaat];
                break;
            case Valuta.Florijn:
                Bedrag *= Omreken[Valuta.Florijn];
                break;
        }
    }

    private void ConvertFromGulden(Valuta muntsoort)
    {
        switch (muntsoort)
        {
            case Valuta.Euro:
                Bedrag /= Omreken[Valuta.Euro];
                break;
            case Valuta.Gulden:

                break;
            case Valuta.Dukaat:
                Bedrag /= Omreken[Valuta.Dukaat];
                break;
            case Valuta.Florijn:
                Bedrag /= Omreken[Valuta.Florijn];
                break;
        }
    }

    public static explicit operator Geld(decimal bedrag)
    {
        return new Geld(Valuta.Euro, bedrag);
    }

    public static explicit operator decimal(Geld geld)
    {
        geld.ConvertTo(Valuta.Euro);
        return geld.ParseBedragToDecimal(geld);
    }
}