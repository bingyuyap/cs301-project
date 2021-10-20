using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services;
using CsvHelper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class DatabaseSeeder
    {
        private readonly ILogger<UserService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public DatabaseSeeder(IServiceScopeFactory scopeFactory,
            ILogger<UserService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public void SeedUserEntries()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "CS301-Spend-Transaction.Repo.Helpers.Seeds.dummy_users.csv";
            
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader, 
                        System.Globalization.CultureInfo.CreateSpecificCulture("enUS"));
                    var users = csvReader.GetRecords<User>();
                    
                    dbContext.Users.AddRange(users);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}