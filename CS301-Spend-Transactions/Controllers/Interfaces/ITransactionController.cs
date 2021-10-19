using System.Transactions;

namespace CS301_Spend_Transactions.Controllers.Interfaces
{
    public interface ITransactionController
    {
        Transaction AddTransaction(Transaction transaction);

        Transaction GetTransactionById(string Id);
    }
}