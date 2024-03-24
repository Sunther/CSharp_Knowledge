using MediatR;
using DomainEvents_MediatR.Domain.Entities;
using DomainEvents_MediatR.Infrastructure.Queries;
using DomainEvents_MediatR.Infrastructure;

namespace DomainEvents_MediatR.Application.Handlers
{
    internal class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<Person>>
    {
        private readonly IDataAccess _DataAccess;

        public GetPersonListHandler(IDataAccess dataAccess)
        {
            _DataAccess = dataAccess;
        }
        public Task<List<Person>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_DataAccess.GetPeople());
        }
    }
}
