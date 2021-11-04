using System.Linq;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Services
{
    public class UserEntriesService : IUserEntriesService 
    {
        private readonly ILogger<UserEntriesService> _logger;
        // Manages the lifetime of the services we going to inject
        private readonly IServiceScopeFactory _scopeFactory;
        
        public UserEntriesService(IServiceScopeFactory scopeFactory,
            ILogger<UserEntriesService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        
        public bool InsertUserEntry(UserEntry userEntry)
        {
            throw new System.NotImplementedException();
        }
    }
}