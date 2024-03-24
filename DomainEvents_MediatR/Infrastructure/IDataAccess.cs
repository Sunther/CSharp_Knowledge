using DomainEvents_MediatR.Domain.Entities;

namespace DomainEvents_MediatR.Infrastructure
{
    internal interface IDataAccess
    {
        List<Person> GetPeople();
        Person InsertPerson(Person p);
    }
}