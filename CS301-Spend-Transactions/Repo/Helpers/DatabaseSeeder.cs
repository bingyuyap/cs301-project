using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Repo.Helpers.Interfaces;
using CS301_Spend_Transactions.Services;
using CsvHelper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<UserService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public DatabaseSeeder(IServiceScopeFactory scopeFactory,
            ILogger<UserService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task<int> SeedUserEntries()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            using (TextReader fileReader = File.OpenText("Repo/Helpers/Seeds/DummyUsers.csv"))
            {
                CsvReader csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                var users = csvReader.GetRecords<User>();
                
                dbContext.Users.AddRange(users);
                return await dbContext.SaveChangesAsync();
            }
        }
        
        public async Task<int> SeedCardEntries()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            using (TextReader fileReader = File.OpenText("Repo/Helpers/Seeds/DummyCards.csv"))
            {
                CsvReader csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                var cards = csvReader.GetRecords<Card>();
                
                dbContext.Cards.AddRange(cards);
                return await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> SeedTransactionEntries()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            using (TextReader fileReader = File.OpenText("Repo/Helpers/Seeds/DummyTransactions.csv"))
            {
                CsvReader csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                var transactions = csvReader.GetRecords<Transaction>();
                
                dbContext.Transactions.AddRange(transactions);
                return await dbContext.SaveChangesAsync();
            }
        }
    }
}