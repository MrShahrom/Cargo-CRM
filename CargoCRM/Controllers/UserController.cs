using CargoCRM.DTOs.UserDTOs;
using CargoCRM.Extensions;
using CargoCRM.Models;
using CargoCRM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CargoCRM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        [HttpGet(Name = "GetAll")]
        public IEnumerable<UserDto> GetAll([FromServices] IUserRepository repository)
        {
            return repository.GetAll().Select(x => x.ToDto());
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id, [FromServices] IUserRepository repository)
        {
            var serversideUser = repository.GetById(id);
            if (serversideUser is null)
                return NotFound();
            return Ok(serversideUser.ToDto());
        }

        [HttpPost]
        public IActionResult Create(CreateUser createUser, [FromServices] IUserRepository repository)
        {
            if (createUser is null)
                return BadRequest("User is null");
            var newId = repository.GetAll().Any() 
                ? repository.GetAll().Max(u => u.Id) + 1 
                : 1;
            var createdUser = new User
            {
                Id = newId,
                Username = createUser.Username,
                Password = createUser.Password,
                Role = createUser.Role
            };
            repository.Add(createdUser);
            
            return Created($"api/user/{createdUser.Id}", createdUser.ToDto());
        }

        [HttpPut]
        public IActionResult Update(int id, UpdateUser updateUser, [FromServices] IUserRepository repository)
        {
            if (updateUser is null)
                return BadRequest("User is null");

            var serversideUser = repository.GetById(id);
            if (serversideUser is null)
                return NotFound();
            
            serversideUser.Username = updateUser.UserName;
            serversideUser.Password = updateUser.Password;
            serversideUser.Role = updateUser.Role;
            
            repository.TryUpdate(id, serversideUser);
            
            return Ok(serversideUser.ToDto());
        }

        [HttpPatch]
        public IActionResult UpdateSpecificProperties(int id, PatchUpdateUser updateUser, [FromServices] IUserRepository repository)
        {
            if (updateUser is null)
                return BadRequest("User is null");
            
            var serversideUser = repository.GetById(id);
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
            return Ok(serversideUser.ToDto());
        }
        
        [HttpDelete]
        public IActionResult Delete(int id, [FromServices] IUserRepository repository)
        {
            var deletedUser = repository.Delete(id);
            if (deletedUser is null)
                return NotFound();
            
            return Ok(deletedUser.ToDto());
        }
    }
}

