using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Repo.Helpers;
using CS301_Spend_Transactions.Repo.Helpers.Interfaces;
using CS301_Spend_Transactions.Services;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;

namespace CS301_Spend_Transactions.Extensions
{
    public static class DataAccessStartup
    {
        public static void AddDataAccessInjections(this IServiceCollection services)
        {
            // Service Injection
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IRuleService, RuleService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IUserService, UserService>();
            
            services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();

        }
    }
}