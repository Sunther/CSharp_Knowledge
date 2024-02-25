using EfficientMapping.DTOs;
using EfficientMapping.Entities;
using Riok.Mapperly.Abstractions;

namespace EfficientMapping.Mappers;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
[UseStaticMapper(typeof(TagMapper))]
public static partial class PersonMapper
{
    public static PersonDto PersonToDto(Person person)
    {
        // custom before map code...
        var dto = ToDto(person);
        // custom after map code...
        return dto;
    }

    [MapProperty(nameof(@Person.Id), nameof(@PersonDto.PersonId))]
    [MapProperty(nameof(@Person.Dis), nameof(@PersonDto.Isd))]
    private static partial PersonDto ToDto(Person person);
}
