using BenchmarkDotNet.Running;
using MultipleOrderBy;
using MultipleOrderBy.DTOs;
using System.Diagnostics;

public class Program
{
    static Wrapper[] Arr = new Wrapper[]
    {
          new() { Name = 1, Price = 2 },
          new() { Name = 0, Price = 1 },
          new() { Name = 2, Price = 1 },
          new() { Name = 2, Price = 0 },
          new() { Name = 0, Price = 2 },
          new() { Name = 0, Price = 3 },
    };

    public static void Main()
    {
        BenchmarkRunner.Run<BenchmarkOrderBy>();

        WrongWay_MultipleOrderBy();
        RightWay_MultipleOrderBy();
    }

    public static void WrongWay_MultipleOrderBy()
    {
        var sw = new Stopwatch();
        var init = DateTime.Now.Ticks;

        sw.Start();
        var result = Arr.OrderBy(item => item.Name)
                        .OrderBy(item => item.Price);
        sw.Stop();

        Console.WriteLine($"Time with OrderBy: {DateTime.Now.Ticks - init} ticks");
    }

    public static void RightWay_MultipleOrderBy()
    {
        var sw = new Stopwatch();
        var init = DateTime.Now.Ticks;

        sw.Start();
        var result = Arr.OrderBy(item => item.Name)
                        .ThenBy(item => item.Price);
        sw.Stop();

        Console.WriteLine($"Time with ThenBy: {DateTime.Now.Ticks - init} ticks");
    }
}