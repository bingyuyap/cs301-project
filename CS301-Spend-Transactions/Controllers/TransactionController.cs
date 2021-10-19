using System.Transactions;
using CS301_Spend_Transactions.Controllers.Interfaces;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Controllers
{
    public class TransactionController : BaseController<TransactionController>, ITransactionController
    {
        private readonly ILogger<TransactionController> _logger;
        private ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, 
            ITransactionService transactionService) : base(logger)
        {
            _logger = logger;
            _transactionService = transactionService;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            throw new System.NotImplementedException();
        }

        public Transaction GetTransactionById(string Id)
        {
            throw new System.NotImplementedException();
        }

        
    }
}