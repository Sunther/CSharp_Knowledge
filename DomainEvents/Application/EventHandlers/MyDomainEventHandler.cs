using DomainEvents.Domain.Events;

namespace DomainEvents.Application.EventHandlers;

public class MyDomainEventHandler : IHandler<MyDomainEvent>
{
    public void Handle(MyDomainEvent domainEvent)
    {
        Console.WriteLine($"Here We Go!. Id: {domainEvent.Id}");
    }
}
