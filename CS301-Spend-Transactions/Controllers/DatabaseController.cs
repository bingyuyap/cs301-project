using CS301_Spend_Transactions.Controllers.Interfaces;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Controllers
{
    public class DatabaseController : BaseController<DatabaseController>, IDatabaseController
    {
        public DatabaseController(ILogger<DatabaseController> logger) : base(logger)
        {
        }

        public void SeedUsers()
        {
            throw new System.NotImplementedException();
        }

        public void SeedCards()
        {
            throw new System.NotImplementedException();
        }

        public void SeedTransactions()
        {
            throw new System.NotImplementedException();
        }
    }
}