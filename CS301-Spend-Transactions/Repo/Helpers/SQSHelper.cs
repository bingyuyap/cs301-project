using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using CS301_Spend_Transactions.Domain.Configurations;
using CS301_Spend_Transactions.Repo.Helpers.Interfaces;
using CS301_Spend_Transactions.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySqlX.XDevAPI.Common;
using Serilog;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class SQSHelper : ISQSHelper
    {
        private readonly SQSOption _option;
        private AmazonSQSClient _amazonSqsClient;
        private ILogger<SQSHelper> _logger;

        public SQSHelper(IOptions<SQSOption> option, ILogger<SQSHelper> logger)
        {
            _option = option.Value;
            _amazonSqsClient = new AmazonSQSClient(
                new BasicAWSCredentials(_option.AccessKey, _option.SecretKey)
            );
            _logger = logger;
        }

        public async Task<List<Message>> GetMessage()
        {
            _logger.LogInformation(
                "[SQSHelper/GetMessages] making new receive message request");
            List<Message> batch = new List<Message>();
            for (int i = 0; i < 10; i++)
            {
                var request = new ReceiveMessageRequest
                {
                    MaxNumberOfMessages = 10,
                    QueueUrl = _option.QueueURL,
                    // VisibilityTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds,
                    // WaitTimeSeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds
                };

                var response = await _amazonSqsClient.ReceiveMessageAsync(request);

                _logger.LogInformation(
                    "[SQSHelper/GetMessages] Finish await messages");
                batch.AddRange(response.Messages.Any() ? response.Messages : new List<Message>());
            }


            // await DeleteMessages(messages);

            return batch;
        }

        public async Task<Message> GetSingleMessage()
        {
            _logger.LogInformation(
                "[SQSHelper/GetMessages] making new receive message request");
            
            var request = new ReceiveMessageRequest
            {
                MaxNumberOfMessages = 1,
                QueueUrl = _option.QueueURL,
                // VisibilityTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds,
                // WaitTimeSeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds
            };

            var response = await _amazonSqsClient.ReceiveMessageAsync(request);
            
            return response.Messages.Single();
        }

        public async Task DeleteMessages(List<Message> messages)
        {
            foreach (var message in messages)
            {
                await _amazonSqsClient.DeleteMessageAsync(new DeleteMessageRequest(_option.QueueURL,
                    message.ReceiptHandle));
            }
        }
    }
}