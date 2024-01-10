using DomainEvents.Domain.Contracts;

namespace DomainEvents.Domain.Events;

public sealed record MyDomainEvent(int Id) : IDomainEvent { }
