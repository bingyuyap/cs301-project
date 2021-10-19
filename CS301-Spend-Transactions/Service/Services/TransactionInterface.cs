using System.Transactions;
using CS301_Spend_Transactions.Controllers.Interfaces;
using CS301_Spend_Transactions.Services.Interfaces;

namespace CS301_Spend_Transactions.Services
{
    public class TransactionInterface : ITransactionService
    {
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