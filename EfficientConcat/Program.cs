using System.Diagnostics;
using System.Text;

UsingConcat();
UsingStringBuilder();

void UsingConcat()
{
    var sw = new Stopwatch();
    var naturalNumbers = Enumerable.Range(1, 1000).ToList();
    var naturalString = string.Empty;

    sw.Start();
    foreach (int item in naturalNumbers)
    {
        if (item % 2 == 0)
        {
            naturalString += $"{item} is Even";
        }
        else
        {
            naturalString += $"{item} is Odd";
        }
    }
    sw.Stop();
    
    Console.WriteLine($"{nameof(UsingConcat)} {sw.ElapsedMilliseconds} mseg");
}


void UsingStringBuilder()
{
    var sw = new Stopwatch();
    var naturalNumbers = Enumerable.Range(1, 1000).ToList();
    var naturalStringBuilder = new StringBuilder();

    sw.Start();
    foreach (int item in naturalNumbers)
    {
        if (item % 2 == 0)
        {
            naturalStringBuilder.Append($"{item} is Even");
        }
        else
        {
            naturalStringBuilder.Append($"{item} is Odd");
        }
    }
    sw.Stop();

    Console.WriteLine($"{nameof(UsingStringBuilder)} {sw.ElapsedMilliseconds} mseg");
}
