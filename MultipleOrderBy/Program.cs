using MultipleOrderBy;
using System.Diagnostics;

MultipleOrderByWrong();
Console.WriteLine("");
MultipleOrderByRight();

///<summary>
/// Reorders the list twice
/// The 𝗢𝗿𝗱𝗲𝗿𝗕𝘆 operator is used to sort a sequence of elements based on a specified key. When multiple OrderBy calls are chained together, each subsequent call completely reorders the list, discarding the results of the previous call. This means that only the last OrderBy call will have any effect on the final ordering of the sequence.
/// Using multiple 𝗢𝗿𝗱𝗲𝗿𝗕𝘆 calls can also lead to performance problems. This is because each OrderBy call performs a full sort of the list, which can be expensive. If you are chaining multiple OrderBy calls together, you are essentially performing multiple full sorts, which can significantly slow down your code.
///</summary>
void MultipleOrderByWrong()
{
    var sw = new Stopwatch();

    var arr = new Wrapper[]
        {
          new() { Name = 1, Price = 2 },
          new() { Name = 0, Price = 1 },
          new() { Name = 2, Price = 1 },
          new() { Name = 2, Price = 0 },
          new() { Name = 0, Price = 2 },
          new() { Name = 0, Price = 3 },
        };

    sw.Start();
    var result = arr.OrderBy(item => item.Name)
                    .OrderBy(item => item.Price);
    sw.Stop();

    Console.WriteLine($"Time with OrderBy: {sw.ElapsedMilliseconds} mseg");
}

///<summary>
/// Reoders the list applying both criteria
/// The 𝗧𝗵𝗲𝗻𝗕𝘆 method is used after the initial OrderBy to apply additional sorting conditions. This ensures that the data is sorted first by the first field (Name in this example), and then by the second field (Price in this example).
/// The 𝗧𝗵𝗲𝗻𝗕𝘆 method in C# can be used to chain multiple sorting criteria together, without the performance overhead of calling OrderBy multiple times.
///</summary>
void MultipleOrderByRight()
{
    var sw = new Stopwatch();

    var arr = new Wrapper[]
        {
          new() { Name = 1, Price = 2 },
          new() { Name = 0, Price = 1 },
          new() { Name = 2, Price = 1 },
          new() { Name = 2, Price = 0 },
          new() { Name = 0, Price = 2 },
          new() { Name = 0, Price = 3 },
        };

    sw.Start();
    var result = arr.OrderBy(item => item.Name)
                    .ThenBy(item => item.Price);
    sw.Stop();

    Console.WriteLine($"Time with ThenBy: {sw.ElapsedMilliseconds} mseg");
}