using Decorator.Contracts;

namespace Decorator.Implementation
{
    public class Addition : IAddition
    {
        public int AddOne(int value)
        {
            return value + 1;
        }
    }
}
