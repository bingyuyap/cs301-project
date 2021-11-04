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
using Microsoft.Extensions.Options;
using MySqlX.XDevAPI.Common;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class SQSHelper : ISQSHelper
    {
        private readonly SQSOption _option;1
        private AmazonSQSClient _amazonSqsClient;

        public SQSHelper(IAmazonSQS sqs, IOptions<SQSOption> option)
        {
            _option = option.Value;
            _amazonSqsClient = new AmazonSQSClient(
                new BasicAWSCredentials(_option.AccessKey, _option.SecretKey)
            ); 
        }

        public async Task<List<Message>> GetMessage()
        {
            var request = new ReceiveMessageRequest
            {
                MaxNumberOfMessages = 10,
                QueueUrl = _option.QueueURL,
                // VisibilityTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds,
                // WaitTimeSeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds
            };
            
            var response = await _amazonSqsClient.ReceiveMessageAsync(request);
            var messages = response.Messages.Any() ? response.Messages : new List<Message>();

            return messages;
        }
    }
}