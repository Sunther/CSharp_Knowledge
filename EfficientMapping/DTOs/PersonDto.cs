namespace EfficientMapping.DTOs;

public class PersonDto
{
    public int PersonId { get; set; }
    public int Isd { get; set; }
    public string Name { get; set; }
    public MartialStatusDto MartialStatus { get; set; }
    public IEnumerable<TagDto> Tags { get; set; }
}
