using CargoCRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoCRM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private static readonly User[] Users =
        [
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "123456",
                Role = "Admin"
            },
            new User()
            {
                Id = 2,
                Username = "user",
                Password = "123456",
                Role = "User"
            }
        ];

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }
    }
}

