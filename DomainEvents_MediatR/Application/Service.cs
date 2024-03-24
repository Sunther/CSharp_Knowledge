using DomainEvents_MediatR.Domain;
using DomainEvents_MediatR.Domain.Entities;
using DomainEvents_MediatR.Infrastructure.Queries;
using MediatR;

namespace DomainEvents_MediatR.Application
{
    internal class Service
    {
        private readonly ILibrary _Library;
        private readonly IMediator _Mediator;

        public Service(ILibrary library, IMediator mediator)
        {
            _Library = library;
            _Mediator = mediator;
        }
        public async Task<List<Person>> GetPeople()
        {
            return await _Mediator.Send(new GetPersonListQuery());
        }
        public async Task<Person> InsertPerson(string firstName, string lastName)
        {
            return await _Library.InsertPerson(firstName, lastName);
        }
    }
}
