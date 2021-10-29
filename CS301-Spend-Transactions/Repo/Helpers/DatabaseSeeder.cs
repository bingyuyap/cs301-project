using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CS301_Spend_Transactions.Domain.Builders;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Repo.Helpers.Interfaces;
using CS301_Spend_Transactions.Services;
using CS301_Spend_Transactions.Services.Interfaces;
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
                csvReader.Read();
                csvReader.ReadHeader();
                
                while (csvReader.Read())
                {
                    var record = new Card
                    {
                        Id = csvReader.GetField("Id"),
                        UserId = csvReader.GetField("UserId"),
                        CardPan = csvReader.GetField("CardPan"),
                        CardType = csvReader.GetField("CardType")
                    };

                    dbContext.Cards.Add(record);
                }
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SeedTransactionEntries()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var cardService = scope.ServiceProvider.GetRequiredService<ICardService>();
            var ruleService = scope.ServiceProvider.GetRequiredService<IRuleService>();
            
            using (TextReader fileReader = File.OpenText("Repo/Helpers/Seeds/DummyTransactions.csv"))
            {
                CsvReader csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                csvReader.Read();
                csvReader.ReadHeader();

                PointBuilder pointBuilder = new PointBuilder();
                while (csvReader.Read())
                {
                    var record = new Transaction
                    {
                        Id = csvReader.GetField("Id"),
                        CardId = csvReader.GetField("CardId"),
                        MerchantName = csvReader.GetField("MerchantName"),
                        TransactionDate = csvReader.GetField<DateTime>("TransactionDate"),
                        Currency = csvReader.GetField("Currency"),
                        Amount = csvReader.GetField<decimal>("Amount")
                    };

                    Card card = cardService.GetCardById(record.CardId);
                    Rule rule = ruleService.GetRule(card, record);
                    PointBuilder point = pointBuilder.Create(rule, card.CardType, record.Id, record.Amount);
                    

                    dbContext.Transactions.Add(record);
                    dbContext.Points.Add(point.Build());
                }
            }
            
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SeedGroupEntries()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            using (TextReader fileReader = File.OpenText("Repo/Helpers/Seeds/Groups.csv"))
            {
                CsvReader csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                csvReader.Read();
                csvReader.ReadHeader();
                while (csvReader.Read())
                {
                    var record = new Groups
                    {
                        MinMCC = csvReader.GetField<int>("MinMCC"),
                        MaxMCC = csvReader.GetField<int>("MaxMCC"), 
                        Name = csvReader.GetField("Name"),
                    };
                    dbContext.Groups.Add(record);
                }
            }
            
            return await dbContext.SaveChangesAsync();
        }
        
        public async Task<int> SeedProgramEntries()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            using (TextReader fileReader = File.OpenText("Repo/Helpers/Seeds/Programs.csv"))
            {
                CsvReader csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                csvReader.Read();
                csvReader.ReadHeader();
                while (csvReader.Read())
                {
                    var record = new CS301_Spend_Transactions.Models.Program
                    {
                        CardType = csvReader.GetField("CardProgram"),
                        Multiplier = csvReader.GetField<decimal>("Earn"),
                        MinSpend = csvReader.GetField<int>("MinSpend"),
                        MaxSpend = csvReader.GetField<int>("MaxSpend"),
                        ForeignSpend = csvReader.GetField<bool>("Foreign")
                    };

                    dbContext.Rules.Add(record);
                }
            }
            
            return await dbContext.SaveChangesAsync();
        }

    }
}