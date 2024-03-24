using Microsoft.Extensions.Hosting;

namespace BackgroundTasks.Implementations
{
    public class PeriodicBackgroundTask : BackgroundService
    {
        private readonly TimeSpan _period = TimeSpan.FromSeconds(5);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(_period);

            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
                Console.WriteLine($"Executing {nameof(PeriodicBackgroundTask)}");
            }
        }
    }
}
