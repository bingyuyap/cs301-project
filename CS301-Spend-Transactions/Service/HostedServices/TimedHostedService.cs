using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IMerchantService _merchantService;

        public TimedHostedService(ILogger<TimedHostedService> logger, ISQSService sqsService,
            ITransactionService transactionService, IMerchantService merchantService)
        {
            _logger = logger;
            _sqsService = sqsService;
            _transactionService = transactionService;
            _merchantService = merchantService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is running");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            // while (!stoppingToken.IsCancellationRequested)
            var sw = Stopwatch.StartNew();
            _logger.LogInformation(
                "[TimedHostedService/DoWork] Starting an iteration");
            
            var checkpoint1 = sw.ElapsedMilliseconds;

            Parallel.For(1, 101, i =>
            {
                var messages = _sqsService.GetMessages();
                _logger.LogInformation($"Consumed {messages.Result.Count} messages from SQS");
                // var message = _sqsService.GetSingleMessage();

                // if (message is null) return;

                var dtos = messages.Result.Select(m => { return TransactionMapperHelper.ToTransactionDTO(m.Body); });
                _logger.LogInformation($"Converted {dtos.Count()} messages to DTO");
                // var dto = TransactionMapperHelper.ToTransactionDTO(message.Result.Body);


                // try
                // {
                //     _logger.LogInformation(dto.ToString());
                //     _merchantService.AddMerchant(dto);
                //     _transactionService.AddTransaction(dto);
                // }
                // catch (InvalidTransactionException e)
                // {
                //     _logger.LogCritical(
                //         $"[TimedHostedService/DoWork] Transaction {dto.Transaction_Id} failed due to {e.Message}");
                // }
                
                Parallel.ForEach(dtos, dto =>
                {
                    try
                    {
                        _logger.LogInformation(dto.ToString());
                        _merchantService.AddMerchant(dto);
                        _transactionService.AddTransaction(dto);
                    }
                    catch (InvalidTransactionException e)
                    {
                        _logger.LogCritical(
                            $"[TimedHostedService/DoWork] Transaction {dto.Transaction_Id} failed due to {e.Message}");
                    }
                });
            });
           



            var checkpoint2 = sw.ElapsedMilliseconds;
            
            _logger.LogInformation($"Time taken for parallel indexing {checkpoint2 - checkpoint1}");
            _logger.LogInformation($"Time taken from consuming to indexing {sw.ElapsedMilliseconds}");

            // await Task.Delay(5, stoppingToken);
        }
    }
}