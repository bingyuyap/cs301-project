using System.Threading;
using System.Threading.Tasks;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Service.HostedServices
{
    public class TimedHostedService : BackgroundService
    {
        
        private readonly ILogger<TimedHostedService> _logger;
        private readonly ISQSService _sqsService;

        public TimedHostedService(ILogger<TimedHostedService> logger, ISQSService sqsService)
        {
            _logger = logger;
            _sqsService = sqsService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is running");
            await DoWork(stoppingToken);
        }
        
        private async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(
                    "[TimedHostedService/DoWork] Starting an iteration");
                
                var messages = await _sqsService.GetMessages();
            }
                

            await Task.Delay(5, stoppingToken);
        }
        
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Timed Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}