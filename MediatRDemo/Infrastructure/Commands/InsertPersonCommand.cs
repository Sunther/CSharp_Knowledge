using MediatR;
using DomainEvents_MediatR.Domain.Entities;

namespace DomainEvents_MediatR.Infrastructure.Commands
{
    internal record InsertPersonCommand(Person Person) : IRequest<Person>;
}
