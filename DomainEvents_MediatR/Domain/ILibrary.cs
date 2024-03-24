using DomainEvents_MediatR.Domain.Entities;

namespace DomainEvents_MediatR.Domain
{
    internal interface ILibrary
    {
        Task<Person> InsertPerson(string firstName, string lastName);
    }
}