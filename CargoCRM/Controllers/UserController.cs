using CargoCRM.DTOs.UserDTOs;
using CargoCRM.Extensions;
using CargoCRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace CargoCRM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private static readonly List<User> Users =
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
                Username = "Abdu",
                Password = "123456",
                Role = "User"
            }
        ];

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<UserDto> GetAll()
        {
            return Users.Select(u => u.ToUserDto());
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public IActionResult Create(CreateUser createUser)
        {
            if (createUser is null)
                return BadRequest("User is null");
            
            var newId = Users.Max(x => x.Id) + 1;
            var createdUser = new User
            {
                Id = newId,
                Username = createUser.Username,
                Password = createUser.Password,
                Role = createUser.Role
            };
            Users.Add(createdUser);
            
            return Created($"api/user/{createdUser.Id}", createdUser.ToUserDto());
        }

        [HttpPut]
        public IActionResult Update(int id, UpdateUser updateUser)
        {
            if (updateUser is null)
                return BadRequest("User is null");

            var serversideUser = Users.SingleOrDefault(x => x.Id == id);
            if (serversideUser is null)
                return NotFound();
            
            serversideUser.Username = updateUser.UserName;
            serversideUser.Password = updateUser.Password;
            serversideUser.Role = updateUser.Role;
            
            return Ok(serversideUser.ToUserDto());
        }

        [HttpPatch]
        public IActionResult UpdateSpecificProperties(int id, PatchUpdateUser updateUser)
        {
            if (updateUser is null)
                return BadRequest("User is null");
            
            var serversideUser = Users.SingleOrDefault(x => x.Id == id);
            if (serversideUser is null)
                return NotFound();
            
            var serversideUserType = serversideUser.GetType();
            var properties = updateUser.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(updateUser);
                if (value != null)
                {
                    var oldProperty = serversideUserType.GetProperty(property.Name);
                    if (oldProperty?.CanWrite == true)
                        oldProperty.SetValue(serversideUser, value);
                }
            }
            return Ok(serversideUser.ToUserDto());
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var serversideUser = Users.SingleOrDefault(x => x.Id == id);
            if (serversideUser is null)
                return NotFound();
            Users.Remove(serversideUser);
            return Ok($"User with id {id} was deleted");
        }
    }
}

