using System;

public class Normaal : Kaart
{
    public Normaal(decimal saldo) : base(saldo)
    {
    }

    public override void Betaal(decimal bedrag)
    {
        if (bedrag > getSaldo())
        {
            throw new InvalidOperationException();
        }
        else
        {
            base.Betaal(bedrag);
        }
    }
    
}