using MoreLinq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        
    }

    private IEnumerable<string> FullOuterJoin(IEnumerable<string> left, IEnumerable<string> right)
    {
        return left // The first list
                    .FullJoin(right, //The other List
                            c => c, //Variable to analyze if matches
                            c => $"{c} {nameof(left)}", // Result left does not exist on right
                            c => $"{c} {nameof(right)}", // Result right does not exist on left
                            (a, b) => $"{a} {b}") // Result if matches left and right
                        ;
    }
}
