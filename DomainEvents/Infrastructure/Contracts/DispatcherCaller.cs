using DomainEvents.Application.EventHandlers;
using DomainEvents.Domain.Events;
using DomainEvents.Infrastructure.Implementations;

namespace DomainEvents.Infrastructure.Contracts
{
    public class DispatcherCaller : IDispatcherCaller
    {
        private readonly IHandler<MyDomainEvent> _handler;

        public DispatcherCaller(IHandler<MyDomainEvent> handler)
        {
            _handler = handler;
        }

        public void JustCall()
        {
            _handler.Handle(new MyDomainEvent(0));
        }
    }
}
