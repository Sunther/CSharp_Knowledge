using FluentValidation;
using System.Text.Json;

namespace FluentValidationDemo
{
    internal class PeopleRepo : IPeopleRepo
    {
        private IValidator<Person> _PersonValidator { get; }

        public PeopleRepo(IValidator<Person> validator)
        {
            _PersonValidator = validator;
        }

        public async Task DoSomething()
        {
            var p = new Person()
            {
                Name = "Test",
                Email = "asbfljhkasb",
                Age = 15
            };

            var res = await _PersonValidator.ValidateAsync(p);
            if (!res.IsValid)
            {
                Console.WriteLine($"There are errors in your dungeon.{Environment.NewLine}{JsonSerializer.Serialize(res.Errors)}");
            }
        }
    }
}
