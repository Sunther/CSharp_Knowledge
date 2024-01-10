using DomainEvents.Application.EventHandlers;
using DomainEvents.Domain.Contracts;
using DomainEvents.Domain.Events;
using DomainEvents.Infrastructure.Contracts;
using DomainEvents.Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DomainEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = GetServiceProvider();
            serviceProvider.GetRequiredService<IDispatcherCaller>().JustCall();
        }

        private static IServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddScoped<IHandler<MyDomainEvent>, MyDomainEventHandler>()
                .AddTransient<IDispatcherCaller, DispatcherCaller>()

                .AddSingleton<IDomainEventsDispatcher, DomainEventsDispatcher>()

                // Build
                .BuildServiceProvider();
        }
    }
}