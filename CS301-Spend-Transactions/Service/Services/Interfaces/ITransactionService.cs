
using CS301_Spend_Transactions.Models;

namespace CS301_Spend_Transactions.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction AddTransaction(Transaction transaction);

        Transaction GetTransactionById(string Id);
    }
}