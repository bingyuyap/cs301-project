using System.Threading.Tasks;

namespace CS301_Spend_Transactions.Repo.Helpers.Interfaces
{
    public interface IDatabaseSeeder
    {
        Task<int> SeedUserEntries();

        Task<int> SeedCardEntries();
        
        Task<int> SeedTransactionEntries();

        Task<int> SeedGroupEntries();
    }
}