namespace MultipleOrderBy.DTOs
{
    public class Wrapper
    {
        public int Name { get; init; }
        public int Price { get; init; }

        public Wrapper(int randomName, int randomPrice)
        {
            Name = randomName;
            Price = randomPrice;
        }
    }
}
