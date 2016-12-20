using Minor.Dag06.MicroOefening;

public class VIPkaart : Kaart
{
    private decimal _kortingspercentage;

    public VIPkaart(decimal beginsaldo, decimal kortingspercentage) : base(beginsaldo)
    {
        _kortingspercentage = kortingspercentage;
    }

    public override void Betaal(decimal bedrag)
    {
        decimal gekortBedrag = bedrag - bedrag * (_kortingspercentage / 100);
        base.Betaal(gekortBedrag);
    }
}