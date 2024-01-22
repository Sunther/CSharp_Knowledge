using Microsoft.Extensions.DependencyInjection;
using Polly;

public class Program
{
    public const string PipelineTag = "Tag";

    /// <summary>
    /// https://www.youtube.com/watch?v=PqVQFUCTzUM
    /// </summary>
    public static void Main()
    {
        var serviceProvider = GenerateServiceProvider();
        serviceProvider.GetRequiredService<IProgramService>().Run();
    }

    private static IServiceProvider GenerateServiceProvider()
    {
        return new ServiceCollection()
                .AddResiliencePipeline<string, string>(PipelineTag, builder =>
                    {
                        builder.AddRetry(new()
                        {
                            MaxRetryAttempts = 5,
                            BackoffType = DelayBackoffType.Constant,
                            Delay = TimeSpan.Zero,
                            ShouldHandle = new PredicateBuilder<string>()
                                        .Handle<Exception>(),
                            OnRetry = retryArguments =>
                            {
                                Console.WriteLine($"Current attempt: {retryArguments.AttemptNumber}\n{retryArguments.Outcome.Exception}");
                                return ValueTask.CompletedTask;
                            }
                        });
                    })

                .AddScoped<IProgramService, ProgramService>()

                // Build
                .BuildServiceProvider();
    }

    //private static void Fallback()
    //{
    //    var pipeline = new ResiliencePipelineBuilder<string>()
    //        .AddFallback(new FallbackStrategyOptions<string>
    //        {
    //            MaxRetryAttempts = 5,
    //            BackoffType = DelayBackoffType.Constant,
    //            Delay = TimeSpan.Zero,
    //            ShouldHandle = new PredicateBuilder()
    //                                .Handle<Exception>(),
    //            OnRetry = retryArguments =>
    //            {
    //                Console.WriteLine($"Current attempt: {retryArguments.AttemptNumber}, {retryArguments.Outcome.Exception}");
    //                return ValueTask.CompletedTask;
    //            }
    //        })
    //        .Build();

    //    pipeline.Execute(ProgramService.Method());
    //}
}