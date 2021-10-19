using System.Transactions;
using CS301_Spend_Transactions.Controllers.Interfaces;

namespace CS301_Spend_Transactions.Controllers
{
    public class TransactionController : ITransactionController
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