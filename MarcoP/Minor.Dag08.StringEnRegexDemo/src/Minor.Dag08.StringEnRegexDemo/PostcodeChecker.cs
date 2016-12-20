using System;
using System.Text.RegularExpressions;

public class PostcodeChecker
{
    private static readonly Regex pattern = new Regex(
        @"^(?<cijfers>[1-9]\d{3}) ?(?<letters>[A-Z]{2}|[a-z]{2})$",
        RegexOptions.Compiled
    );

    public bool Check(string postcode)
    {
        return pattern.IsMatch(postcode);
    }

    public string Cijfers(string postcode)
    {
        var match = pattern.Matches(postcode)[0];
        return match.Groups["cijfers"].Value;
    }

    public string Letters(string postcode)
    {
        var match = pattern.Matches(postcode)[0];
        return match.Groups["letters"].Value;
    }
}