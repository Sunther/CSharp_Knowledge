using Microsoft.Extensions.Hosting;

namespace BackgroundTasks.Implementations
{
    internal class PeriodicHostedLifecycleService : IHostedLifecycleService
    {
        private readonly TimeSpan _period = TimeSpan.FromSeconds(5);

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Start Async");
        }

        public async Task StartedAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started Async");
            using var timer = new PeriodicTimer(_period);

            while (!cancellationToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(cancellationToken))
            {
                Console.WriteLine($"Executing {nameof(PeriodicBackgroundTask)}");
            }
        }

        public async Task StartingAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting Async");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop Async");
        }

        public async Task StoppedAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopped Async");
        }

        public async Task StoppingAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping Async");
        }
    }
}
