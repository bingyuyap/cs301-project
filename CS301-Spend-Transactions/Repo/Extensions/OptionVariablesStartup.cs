using System;
using System.IO;
using CS301_Spend_Transactions.Domain.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CS301_Spend_Transactions.Extensions
{
    public static class OptionVariablesStartup
    {
        public static void AddOptionVariables(this IServiceCollection services, IWebHostEnvironment env,
            IConfiguration configuration)
        {
            var sqsConfig =  GetSqsOption(configuration, env);
            
            if (sqsConfig == null)
                throw new InvalidDataException("Invalid sqsConfig object received.");
            
            services.Configure<SQSOption>(options =>
            {
                options.QueueURL = sqsConfig.QueueURL;
                options.Region = sqsConfig.Region;
            });
        }

        private static SQSOption GetSqsOption(IConfiguration configuration, IWebHostEnvironment env)
        {
            var queueUrl = Environment.GetEnvironmentVariable("QueueUrl");
            var region = Environment.GetEnvironmentVariable("SQSRegion");
            var accessKey = Environment.GetEnvironmentVariable("AWSAccessKey");
            var secretKey = Environment.GetEnvironmentVariable("AWSSecretKey");

            if (string.IsNullOrEmpty(queueUrl) || string.IsNullOrEmpty(region) || string.IsNullOrEmpty(accessKey) ||
                string.IsNullOrEmpty(secretKey)) 
                return null;

            return new SQSOption(queueUrl, region, accessKey, secretKey);
        }
    }
}