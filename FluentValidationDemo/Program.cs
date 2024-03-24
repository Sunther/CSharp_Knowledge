using FluentValidation;
using FluentValidationDemo;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    /// <summary>
    /// DOCU: https://docs.fluentvalidation.net/en/latest/aspnet.html
    /// </summary>
    public static void Main()
    {
        var serviceProvider = ConfigureServices();
        serviceProvider.GetRequiredService<IPeopleRepo>().DoSomething();
    }

    /// <summary>
    /// Registro de los servicios
    /// </summary>
    private static ServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddScoped<IValidator<Person>, PersonValidator>()
            //.AddValidatorsFromAssemblyContaining<PersonValidator>()

            //Infra
            .AddScoped<IPeopleRepo, PeopleRepo>()

            // Build
            .BuildServiceProvider();
    }
}