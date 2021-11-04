using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Services
{
    public class SQSService
    {
        private readonly ILogger<SQSService> _logger;
        private readonly IAmazonSQS _sqs;

        public SQSService(ILogger<SQSService> logger, IAmazonSQS sqs)
        {
            _logger = logger;
            _sqs = sqs;
        }
    }
}