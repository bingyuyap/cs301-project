using CS301_Spend_Transactions.Controllers.Interfaces;
using CS301_Spend_Transactions.Models;
using CS301_Spend_Transactions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS301_Spend_Transactions.Controllers
{
    public class UserController : BaseController<UserController>, IUserController
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
        {
            _logger = logger;
            _userService = userService;
        }
        
        [HttpPost("/api/User/AddUser")]
        public User AddUser(User user)
        {
            return _userService.AddUser(user);
        }
        
        [HttpGet("/api/User/GetUser")]

        public User GetUsetById(string Id)
        {
            return _userService.GetUserById(Id);
        }
    }
}