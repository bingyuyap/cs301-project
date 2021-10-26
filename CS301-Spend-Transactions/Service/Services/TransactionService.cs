using System.Linq;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ILogger<TransactionService> _logger;
        // Manages the lifetime of the services we going to inject
        private readonly IServiceScopeFactory _scopeFactory;

        public TransactionService(IServiceScopeFactory scopeFactory,
            ILogger<TransactionService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Add(transaction);
            dbContext.SaveChanges();

            return transaction;
        }

        public Transaction GetTransactionById(string Id)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Using LINQ expressions here
            return dbContext.Transactions.First(transaction => transaction.Id == Id);
        }
    }
}