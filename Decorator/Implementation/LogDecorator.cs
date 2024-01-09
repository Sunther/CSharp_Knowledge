using Decorator.Contracts;

namespace Decorator.Implementation
{
    public class LogDecorator : IAddition
    {
        private IAddition _Client;

        public LogDecorator(IAddition client)
        {
            _Client = client;
        }

        public int AddOne(int value)
        {
            Console.WriteLine($"Write Before Main Code");
            var result = _Client.AddOne(value);
            Console.WriteLine($"Write After Main Code {result}");

            return result;
        }
    }
}
