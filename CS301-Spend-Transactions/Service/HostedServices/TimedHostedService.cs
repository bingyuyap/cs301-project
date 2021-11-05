using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CS301_Spend_Transactions.Domain.Exceptions;
using CS301_Spend_Transactions.Repo.Helpers;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Service.HostedServices
{
    public class TimedHostedService : BackgroundService
    {
        
        private readonly ILogger<TimedHostedService> _logger;
        private readonly ISQSService _sqsService;
        private readonly ITransactionService _transactionService;

        public TimedHostedService(ILogger<TimedHostedService> logger, ISQSService sqsService, ITransactionService transactionService)
        {
            _logger = logger;
            _sqsService = sqsService;
            _transactionService = transactionService;
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
                _logger.LogInformation($"Consumed {messages.Count} messages from SQS");

                var dtos = messages.Select(m =>
                {
                    return TransactionMapperHelper.ToTransactionDTO(m.Body);
                });
                _logger.LogInformation($"Converted {dtos.Count()} messages to DTO");

                foreach (var dto in dtos)
                {
                    try
                    {
                        _logger.LogInformation(dto.ToString());
                        _transactionService.AddTransaction(dto);
                    }
                    catch (InvalidTransactionException e)
                    {
                        _logger.LogCritical(
                            $"[TimedHostedService/DoWork] Transaction {dto.Transaction_Id} failed due to {e.Message}");
                    }
                }
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