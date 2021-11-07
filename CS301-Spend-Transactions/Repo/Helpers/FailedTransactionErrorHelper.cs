using System.Linq;
using System.Transactions;
using CS301_Spend_Transactions.Domain.DTO;
using CS301_Spend_Transactions.Models;
using Microsoft.EntityFrameworkCore;
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

        private void persistFailedTransaction(TransactionDTO transactionDto)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var failedTransactions = dbContext.FailedTransactions.Where(
                t => t.Transaction_Id == transactionDto.Transaction_Id
            );

            FailedTransaction failedTransaction = null;

            if (failedTransactions.Any())
            {
                failedTransaction = failedTransactions.First();
            }
            else
            {
                failedTransaction = DtoToFailedTransaction(transactionDto);
            }

            failedTransaction.Count++;

            dbContext.FailedTransactions.Add(failedTransaction);
            dbContext.SaveChangesAsync();
        }

        private FailedTransaction DtoToFailedTransaction(TransactionDTO transactionDto)
        {
            return new FailedTransaction
            {
                Id = transactionDto.Id,
                Transaction_Id = transactionDto.Transaction_Id,
                Merchant = transactionDto.Merchant,
                MCC = transactionDto.MCC,
                Currency = transactionDto.Currency,
                Amount = transactionDto.Amount,
                Transaction_Date = transactionDto.Transaction_Date,
                Card_Id = transactionDto.Card_Id,
                Card_Pan = transactionDto.Card_Pan,
                Card_Type = transactionDto.Card_Type,
                Count = 0
            };
        }
    }
}