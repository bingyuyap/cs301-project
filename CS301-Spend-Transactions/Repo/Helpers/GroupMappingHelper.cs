using CS301_Spend_Transactions.Repo.Helpers.Interfaces;
using CS301_Spend_Transactions.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Repo.Helpers
{
    public class GroupMappingHelper : IGroupMappingHelper
    {
        private readonly ILogger<UserService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public GroupMappingHelper(IServiceScopeFactory scopeFactory,
            ILogger<UserService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        
        public string GetGroupFromMCC(int MCC)
        {
            
        }
    }
}