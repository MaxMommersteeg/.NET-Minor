using System;
using System.Diagnostics;

public class VIP : Kaart
{
    private decimal Korting { get; set; }

    public VIP(decimal saldo, decimal korting) : base(saldo)
    {
        Debug.WriteLine(korting);

        Korting = (100-korting)/100;
        Debug.WriteLine(Korting);
    }

    public override void Betaal(decimal bedrag)
    {
        bedrag *= Korting;
        base.Betaal(bedrag);
    }



}