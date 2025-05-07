using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CargoCRM.DTOs.UserDTOs;

public record CreateUser
{
    [MinLength(3), MaxLength(30)]
    public string Username { get; init; }
    //[FromHeader]
    public string Password { get; init; }
    // [FromHeader]
    public string Role { get; init; }
}