using Microsoft.Extensions.Hosting;

namespace BackgroundTasks.Implementations
{
    internal class PeriodicHostedService : IHostedService
    {
        private readonly TimeSpan _period = TimeSpan.FromSeconds(5);

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Start Async");
            using var timer = new PeriodicTimer(_period);

            while (!cancellationToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(cancellationToken))
            {
                Console.WriteLine($"Executing {nameof(PeriodicBackgroundTask)}");
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop Async");
        }
    }
}
