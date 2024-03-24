using DomainEvents_MediatR.Domain.Entities;
using DomainEvents_MediatR.Infrastructure.Commands;
using MediatR;

namespace DomainEvents_MediatR.Domain
{
    internal class Library : ILibrary
    {
        private readonly IMediator _Mediator;

        public Library(IMediator mediator)
        {
            _Mediator = mediator;
        }
        public async Task<Person> InsertPerson(string firstName, string lastName)
        {
            return await _Mediator.Send(new InsertPersonCommand(
                                    new Person(firstName, lastName)
                                ));
        }
    }
}
