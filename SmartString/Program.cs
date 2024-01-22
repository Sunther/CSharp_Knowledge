using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        RegexHelper.RegexExample();
        TestRegex(@"^a\d+|b\w*");

        TestDateTime(DateTime.Now, "G"); //Ctrl + Spacebar
    }

    static void TestDateTime(DateTime dateTime, [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string format) { }
    static void TestRegex([StringSyntax(StringSyntaxAttribute.Regex)] string regex) { }
}

internal static partial class RegexHelper
{
    [GeneratedRegex("{(~[0-9]{1,3})+}")]
    internal static partial Regex RegexExample();
}