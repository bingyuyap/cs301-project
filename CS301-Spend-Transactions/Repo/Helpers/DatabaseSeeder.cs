using CS301_Spend_Transactions.Services;
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
    }
}