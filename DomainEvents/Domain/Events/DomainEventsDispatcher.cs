using DomainEvents.Application.EventHandlers;
using DomainEvents.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace DomainEvents.Domain.Events;

public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventsDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Dispatch(IDomainEvent domainEvent)
    {
        var handlerType = typeof(IHandler<>).MakeGenericType(domainEvent.GetType());
        var handlers = _serviceProvider.GetServices(handlerType);

        foreach (dynamic? handler in handlers)
        {
            handler?.Handle((dynamic)domainEvent);
        }
    }
}
