using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Services
{
    public class RewardService : IRewardService
    {
        private readonly ILogger<RewardService> _logger;
        // Manages the lifetime of the services we going to inject
        private readonly IServiceScopeFactory _scopeFactory;
        
        public RewardService(IServiceScopeFactory scopeFactory,
            ILogger<RewardService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        } 
    }
}