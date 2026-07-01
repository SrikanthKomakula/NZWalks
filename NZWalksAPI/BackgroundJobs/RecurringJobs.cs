
using System.ComponentModel;

namespace NZWalksAPI.BackgroundJobs
{
    public class RecurringJobs: BackgroundService
    {
        public RecurringJobs() { }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //throw new NotImplementedException();
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("Recurring job is executing");
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
            }
            catch (OperationCanceledException) { 
                Console.WriteLine("RecurringJobs job is AsyncCompletedEventArgs done");
            }
            

        }
    }
}
