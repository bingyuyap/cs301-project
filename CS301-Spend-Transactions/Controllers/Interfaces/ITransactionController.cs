
using CS301_Spend_Transactions.Models;

namespace CS301_Spend_Transactions.Controllers.Interfaces
{
    public interface ITransactionController
    {
        Transaction AddTransaction(Transaction transaction);

        Transaction GetTransactionById(string Id);
    }
}