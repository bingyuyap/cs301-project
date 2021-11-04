using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using CS301_Spend_Transactions.Repo.Helpers;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.BC;

namespace CS301_Spend_Transactions.Services
{
    public class SQSService
    {
        private readonly ILogger<SQSService> _logger;
        private readonly SQSHelper _sqsHelper;

        public SQSService(ILogger<SQSService> logger, SQSHelper sqsHelper)
        {
            _logger = logger;
            _sqsHelper = sqsHelper;
        }

        public async void GetMessages()
        {
            var messages = await _sqsHelper.GetMessage();

            foreach (var message in messages)
            {
                _logger.LogInformation(message.ToString());
            }   
        }
    }
}