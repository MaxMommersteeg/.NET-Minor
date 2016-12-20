public class Valuta
{
    private readonly Muntsoort _muntsoort;
    private readonly decimal _bedrag;

    public Valuta(decimal bedrag, Muntsoort muntsoort)
    {
        this._bedrag = bedrag;
        this._muntsoort = muntsoort;
    }

    public override string ToString()
    {
        return string.Format("EUR {0:N2}", _bedrag);
    }
}