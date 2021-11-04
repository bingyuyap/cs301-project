using System.Linq;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Services
{
    public class SpendEntriesService : ISpendEntriesService
    {
        private readonly ILogger<SpendEntriesService> _logger;
        // Manages the lifetime of the services we going to inject
        private readonly IServiceScopeFactory _scopeFactory;
        
        public SpendEntriesService(IServiceScopeFactory scopeFactory,
            ILogger<SpendEntriesService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        
        public bool InsertSpendEntry(SpendEntry spendEntry)
        {
            throw new System.NotImplementedException();
        }
    }
}