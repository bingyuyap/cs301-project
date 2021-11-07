using System.Transactions;
using CS301_Spend_Transactions.Domain.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class FailedTransactionErrorHelper
    {
        private readonly ILogger<FailedTransactionErrorHelper> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public FailedTransactionErrorHelper(IServiceScopeFactory scopeFactory,
            ILogger<FailedTransactionErrorHelper> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public void handleFailedTransaction(TransactionDTO transactionDto)
        {
        }
    }
}