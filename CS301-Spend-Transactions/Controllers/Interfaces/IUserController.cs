using CS301_Spend_Transactions.Models;
using Microsoft.AspNetCore.Mvc;

namespace CS301_Spend_Transactions.Controllers.Interfaces
{
    public interface IUserController
    {
        User AddUser(User user);

        User GetUsetById(string Id);
    }
}