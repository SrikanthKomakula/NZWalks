
namespace NZWalksAPI.BackgroundJobs
{
    public class LogCleanupService: BackgroundService
    {
        public ILogger  _logger;

        public LogCleanupService(ILogger logger) {
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken ct)
        {

            while (!ct.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Job Started");

                    //NEed to run code which to run evrty 24 hours

                }
                catch (Exception ex) when (!ct.IsCancellationRequested) 
                {
                    _logger.LogError(ex.ToString(), "This is log error");

                }
                await Task.Delay(TimeSpan.FromHours(24));
            }
            
        }
    }
}
