using EfficientMapping.Entities;
using EfficientMapping.Mappers;
using System.Diagnostics;

namespace EfficientMapping;

public class Program
{
    /// <summary>
    /// https://github.com/riok/mapperly?tab=readme-ov-file
    /// Mapperly
    /// </summary>
    public static void Main()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Person person = new()
        {
            Id = 1,
            Dis = 2,
            MartialStatus = MartialStatus.Married,
            Name = "Test",
            Tags = new List<Tag>() { new("1") }
        };

        var personDto = PersonMapper.PersonToDto(person);

        stopwatch.Stop();
        Console.WriteLine(person);
        Console.WriteLine(personDto);
        Console.WriteLine($"Time {stopwatch.ElapsedMilliseconds} mseg");
    }
}
