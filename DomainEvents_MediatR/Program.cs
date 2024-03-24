using DomainEvents_MediatR.Application;
using DomainEvents_MediatR.Application.Handlers;
using DomainEvents_MediatR.Domain;
using DomainEvents_MediatR.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DomainEvents_MediatR;

internal static class Program
{
    private static async Task Main()
    {
        var sp = ServiceProviderDotNet();
        var service = sp.GetRequiredService<Service>();

        var test1 = await service.InsertPerson("Test1", "TestLastName1");
        Console.WriteLine($"Inserted: {JsonConvert.SerializeObject(test1)}");
        var test2 = await service.InsertPerson("Test2", "TestLastName2");
        Console.WriteLine($"Inserted: {JsonConvert.SerializeObject(test2)}");

        var people = await service.GetPeople();
        Console.WriteLine($"All Inserted: {JsonConvert.SerializeObject(people)}");
    }

    private static IServiceProvider ServiceProviderDotNet()
    {
        IServiceCollection sc = new ServiceCollection();

        sc.AddTransient<Service>();
        sc.AddTransient<ILibrary, Library>();
        sc.AddSingleton<IDataAccess, Repository>();

        //Register all MediatR related
        sc.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPersonListHandler).Assembly));

        return sc.BuildServiceProvider();
    }
}