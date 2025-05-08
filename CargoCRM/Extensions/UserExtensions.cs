using CargoCRM.DTOs.UserDTOs;
using CargoCRM.Models;

namespace CargoCRM.Extensions;

public static class UserExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Role = user.Role
        };
    }

    // public static PackageDto ToDto(this Package package)
    // {
    //     return new PackageDto
    //     {
    //         Id = package.Id,
    //         
    //     }
    // }
}