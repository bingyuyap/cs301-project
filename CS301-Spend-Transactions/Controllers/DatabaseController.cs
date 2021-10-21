using CS301_Spend_Transactions.Controllers.Interfaces;
using CS301_Spend_Transactions.Repo.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Controllers
{
    public class DatabaseController : BaseController<DatabaseController>, IDatabaseController
    {
        private readonly ILogger<DatabaseController> _logger;
        private IDatabaseSeeder _databaseSeeder;
        
        public DatabaseController(ILogger<DatabaseController> logger, IDatabaseSeeder databaseSeeder) : base(logger)
        {
            _logger = logger;
            _databaseSeeder = databaseSeeder;
        }

        [HttpGet("/api/Database/SeedUsers")]
        public async void SeedUsers()
        {
            await _databaseSeeder.SeedUserEntries();
        }

        public void SeedCards()
        {
            throw new System.NotImplementedException();
        }

        public void SeedTransactions()
        {
            throw new System.NotImplementedException();
        }
    }
}