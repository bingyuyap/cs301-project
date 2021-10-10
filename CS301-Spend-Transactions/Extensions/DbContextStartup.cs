using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CS301_Spend_Transactions.Extensions
{
    public class DbContextStartup
    {
        private static string GetConnectionStrings(IWebHostEnvironment env, IConfiguration configuration,
            IDictionary<string, object> vault)
        {
            if (!env.IsProduction())
                return configuration.GetConnectionString($"DefaultConnection:{Environment.MachineName}");

            // TODO: Need to set Db name during deployment
            var connectionString = Environment.GetEnvironmentVariable("transactionDb");
            return !string.IsNullOrEmpty(connectionString) ? connectionString : null;
        }
    }
}