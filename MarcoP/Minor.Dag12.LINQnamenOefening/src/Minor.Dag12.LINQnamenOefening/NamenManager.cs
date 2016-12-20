using System;
using System.Collections.Generic;
using System.Linq;

public class NamenManager
{
    private List<string> _namen;

    public NamenManager(List<string> namen)
    {
        _namen = namen;
    }

    public IEnumerable<char> VoorlettersVanNamenMetR() // _Comprehension
    {
        return from naam in _namen
               where naam.Contains('r') || naam.Contains('R')
               select naam[0];
    }

    public IEnumerable<char> VoorlettersVanNamenMetR_ExtenstionMethod()
    {
        return _namen.Where(naam => naam.Contains('r') || naam.Contains('R'))
                     .Select(naam => naam.First());
    }

    public IEnumerable<int> AantalLettersVanNamenBeginnendMet_J_AflopendGesorteerd()
    {
        return from naam in _namen
               where naam[0] == 'J'
               orderby naam.Length descending
               select naam.Length;

    }

    public IEnumerable<int> AantalNamenMetPerAantalLetters()
    {
        return from naam in _namen
               group naam by naam.Length into zelfdeLengteGroep
               let aantalNamen = zelfdeLengteGroep.Count()
               where aantalNamen > 0
               orderby zelfdeLengteGroep.Key
               select aantalNamen;
    }

    public IEnumerable<string> AlleKortsteNamenZonderA_AlfabetischGesorteerd()
    {
        throw new NotImplementedException();
    }
}