using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CS301_Spend_Transactions.Extensions
{
    public static class DataAccessStartup
    {
        public static void AddDataAccessInjections(this IServiceCollection services)
        {
            // Service Injection
            services.AddTransient<IUserService, UserService>();

        }
    }
}