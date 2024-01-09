using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        RegexHelper.RegexExample();
    }
}

internal static partial class RegexHelper
{
    [GeneratedRegex("{(~[0-9]{1,3})+}")]
    internal static partial Regex RegexExample();
}