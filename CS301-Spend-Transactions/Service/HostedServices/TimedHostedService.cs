using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace CS301_Spend_Transactions.Service.HostedServices
{
    public class TimedHostedService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}