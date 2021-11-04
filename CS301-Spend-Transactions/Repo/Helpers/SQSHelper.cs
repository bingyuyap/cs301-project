using System;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using CS301_Spend_Transactions.Domain.Configurations;
using CS301_Spend_Transactions.Services;
using Microsoft.Extensions.Options;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class SQSHelper
    {
        private readonly IAmazonSQS _sqs;
        private readonly SQSOption _option;
        private AmazonSQSClient _amazonSqsClient;

        public SQSHelper(IAmazonSQS sqs, IOptions<SQSOption> option)
        {
            _sqs = sqs;
            _option = option.Value;
            _amazonSqsClient = new AmazonSQSClient();
        }

        public Task<ReceiveMessageResponse> GetMessage()
        {
            var request = new ReceiveMessageRequest
            {
                MaxNumberOfMessages = 10,
                QueueUrl = _option.QueueURL,
                VisibilityTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds,
                WaitTimeSeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds
            };
            
            return _amazonSqsClient.ReceiveMessageAsync(request);
        }
    }
}