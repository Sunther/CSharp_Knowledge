namespace DomainEvents.Domain.Contracts
{
    public interface IDomainEventsDispatcher
    {
        void Dispatch(IDomainEvent domainEvent);
    }
}