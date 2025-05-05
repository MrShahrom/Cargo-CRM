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
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Test()
        {
            return Ok("Test Post");
        }

        [HttpPut]
        public IActionResult TestPut()
        {
            return Ok("Test Updated");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Test Deleted");
        }
    }
}

