using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace CS301_Spend_Transactions.Service.HostedServices
{
    public class TimedHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}