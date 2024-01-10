using DomainEvents.Domain.Contracts;

namespace DomainEvents.Application.EventHandlers;

public interface IHandler<T> where T : IDomainEvent
{
    void Handle(T domainEvent);
}
