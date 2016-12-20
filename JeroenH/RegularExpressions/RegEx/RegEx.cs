using System;
using System.Text.RegularExpressions;

public class RegEx
{
    Regex pattern = new Regex(@"^[-]?\d{1,3}(,\d{3})*\.\d{2}$",
        RegexOptions.Compiled 
        );

    public bool Check(string getal)
    {
        return pattern.IsMatch(getal);
    }
}