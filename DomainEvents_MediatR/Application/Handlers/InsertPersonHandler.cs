using MediatR;
using DomainEvents_MediatR.Domain.Entities;
using DomainEvents_MediatR.Infrastructure;
using DomainEvents_MediatR.Infrastructure.Commands;

namespace DomainEvents_MediatR.Application.Handlers
{
    internal class InsertPersonHandler : IRequestHandler<InsertPersonCommand, Person>
    {
        private readonly IDataAccess _DataAccess;

        public InsertPersonHandler(IDataAccess dataAccess)
        {
            _DataAccess = dataAccess;
        }
        public Task<Person> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_DataAccess.InsertPerson(request.Person));
        }
    }
}
