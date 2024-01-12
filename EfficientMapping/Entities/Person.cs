namespace EfficientMapping.Entities;

public class Person
{
    public int Id { get; set; }
    public int Dis { get; set; }
    public string Name { get; set; }
    public MartialStatus MartialStatus { get; set; }
    public List<Tag> Tags { get; set; }
}
