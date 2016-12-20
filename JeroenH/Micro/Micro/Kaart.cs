using System;

public class Kaart
{
    private decimal Saldo;

    public decimal getSaldo()
    {
        return Saldo;
    }

    internal void setSaldo(decimal saldo)
    {
        this.Saldo = saldo;
    }

    public Kaart(decimal saldo)
    {
        this.Saldo = saldo;
    }

    public virtual void  Betaal(decimal bedrag)
    {
        this.Saldo -= bedrag;
    }
}