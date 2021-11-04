using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Service.HostedServices
{
    public class TimedHostedService : BackgroundService
    {
        
        private readonly ILogger<TimedHostedService> _logger;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queue Injection Hosted Service is running");
            await DoWork(stoppingToken);
        }
        
        private async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
                _logger.LogInformation(
                    "Consume Scoped Service Hosted Service is working.");
        }
        
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}