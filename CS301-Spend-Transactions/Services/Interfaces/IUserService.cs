using CS301_Spend_Transactions.Models;

namespace CS301_Spend_Transactions.Services.Interfaces
{
    public interface IUserService
    {
        User getUserById(string Id);

        User addUser(User user);
    }
}