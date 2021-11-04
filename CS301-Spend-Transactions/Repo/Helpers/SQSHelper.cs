using Amazon.SQS;
using CS301_Spend_Transactions.Domain.Configurations;
using CS301_Spend_Transactions.Services;
using Microsoft.Extensions.Options;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class SQSHelper
    {
        private readonly IAmazonSQS _sqs;
        private readonly SQSOption _option;

        public SQSHelper(IAmazonSQS sqs, IOptions<SQSOption> option)
        {
            _sqs = sqs;
            _option = option.Value;
        }
    }
}