using Minor.Dag06.MicroOefening;
using System;

public class NormaleKaart : Kaart
{
    public NormaleKaart(decimal beginsaldo) : base(beginsaldo)
    {
    }
        
    public override void Betaal(decimal bedrag)
    {
        if (Saldo - bedrag >= 0)
        {
            base.Betaal(bedrag);
        }
        else
        {
            throw new InvalidOperationException();
        }
        
    }
}