using System.Data;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public UserService(IServiceScopeFactory scopeFactory,
            ILogger<UserService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        
        public User getUserById(string Id)
        {
            throw new System.NotImplementedException();
        }

        public User addUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }

}