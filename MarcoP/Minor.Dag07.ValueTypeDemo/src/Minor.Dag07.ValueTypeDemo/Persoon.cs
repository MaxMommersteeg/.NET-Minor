using Minor.Dag07.ValueTypeDemo;

public class Persoon
{
    public Geslacht Geslacht { get; set; }
    private string _naam;

    public Persoon(string naam, Geslacht geslacht)
    {
        _naam = naam;
        Geslacht = geslacht;
    }

}