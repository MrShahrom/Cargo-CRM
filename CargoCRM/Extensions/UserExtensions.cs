using CargoCRM.DTOs.UserDTOs;
using CargoCRM.Models;

namespace CargoCRM.Extensions;

public static class UserExtensions
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Role = user.Role
        };
    }
}