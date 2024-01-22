using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Retry;

public class Program
{
    public static void Main()
    {
        var serviceProvider = GenerateServiceProvider();

        Polly();
        ResiliencePipelineBuilder();
        Fallback();
    }

    private static IServiceProvider GenerateServiceProvider()
    {
        return new ServiceCollection()
                .AddResiliencePipeline()
            
                // Build
                .BuildServiceProvider();
    }

    private static void Polly()
    {
        var policy = Policy
            .Handle<Exception>()
            .Retry(5, (ex, retryCount) =>
            {
                Console.WriteLine($"Current attempt: {retryCount}, {ex}");
            });

        policy.Execute(() => ProgramService.Method());
    }

    private static void ResiliencePipelineBuilder()
    {
        var pipeline = new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions
            {
                MaxRetryAttempts = 5,
                BackoffType = DelayBackoffType.Constant,
                Delay = TimeSpan.Zero,
                ShouldHandle = new PredicateBuilder()
                                    .Handle<Exception>(),
                OnRetry = retryArguments =>
                {
                    Console.WriteLine($"Current attempt: {retryArguments.AttemptNumber}, {retryArguments.Outcome.Exception}");
                    return ValueTask.CompletedTask;
                }
            })
            .Build();

        pipeline.Execute(() => ProgramService.Method());
    }

    private static void Fallback()
    {
        var pipeline = new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions
            {
                MaxRetryAttempts = 5,
                BackoffType = DelayBackoffType.Constant,
                Delay = TimeSpan.Zero,
                ShouldHandle = new PredicateBuilder()
                                    .Handle<Exception>(),
                OnRetry = retryArguments =>
                {
                    Console.WriteLine($"Current attempt: {retryArguments.AttemptNumber}, {retryArguments.Outcome.Exception}");
                    return ValueTask.CompletedTask;
                }
            })
            .Build();

        pipeline.Execute(() => ProgramService.Method());
    }
}