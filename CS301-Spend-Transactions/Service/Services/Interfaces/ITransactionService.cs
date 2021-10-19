using System.Transactions;

namespace CS301_Spend_Transactions.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction AddTransaction(Transaction transaction);

        Transaction GetTransactionById(string Id);
    }
}