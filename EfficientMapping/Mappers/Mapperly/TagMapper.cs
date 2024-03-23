using EfficientMapping.DTOs;
using EfficientMapping.Entities;
using Riok.Mapperly.Abstractions;

namespace EfficientMapping.Mappers.Mapperly;

[Mapper]
public static partial class TagMapper
{
    public static string MapTag(string name) => $"Tag:{name}";
    
    [MapProperty(nameof(@Tag.Name), nameof(@TagDto.Tag))]
    public static partial TagDto MapTag(Tag tag);
}