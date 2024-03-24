using MediatR;
using DomainEvents_MediatR.Domain.Entities;

namespace DomainEvents_MediatR.Infrastructure.Queries
{
    internal record GetPersonListQuery() : IRequest<List<Person>>;
}
