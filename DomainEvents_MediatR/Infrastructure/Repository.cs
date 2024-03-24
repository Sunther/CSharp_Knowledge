using DomainEvents_MediatR.Domain.Entities;

namespace DomainEvents_MediatR.Infrastructure
{
    internal class Repository : IDataAccess
    {
        private readonly List<Person> _People;

        public Repository()
        {
            _People = new();
        }

        public List<Person> GetPeople()
        {
            return _People;
        }
        public Person InsertPerson(Person p)
        {
            _People.Add(p);

            return p;
        }
    }
}
