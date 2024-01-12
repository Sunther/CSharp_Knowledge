using EfficientMapping.DTOs;
using EfficientMapping.Entities;
using Riok.Mapperly.Abstractions;
using System.Diagnostics;

namespace EfficientMapping;

public class Program
{
    /// <summary>
    /// https://github.com/riok/mapperly?tab=readme-ov-file
    /// </summary>
    /// <param name="args"></param>
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

        var personDto = new PersonMapper().PersonToDto(person);

        stopwatch.Stop();
        Console.WriteLine(person);
        Console.WriteLine(personDto);
        Console.WriteLine($"Time {stopwatch.ElapsedMilliseconds} mseg");
    }
}

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
[UseStaticMapper(typeof(TagMapper))]
public partial class PersonMapper
{
    public PersonDto PersonToDto(Person person)
    {
        // custom before map code...
        var dto = ToDto(person);
        // custom after map code...
        return dto;
    }

    [MapProperty(nameof(Person.Id), nameof(PersonDto.PersonId))]
    [MapProperty(nameof(Person.Dis), nameof(PersonDto.Isd))]
    private partial PersonDto ToDto(Person person);
}

public static class TagMapper
{
    [MapProperty(nameof(Tag.Name), nameof(TagDto.tag))]
    public static TagDto MapTag(Tag tag) => new($"Tag:{tag.Name}");
}