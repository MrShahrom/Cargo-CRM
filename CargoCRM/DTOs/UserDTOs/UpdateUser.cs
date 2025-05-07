namespace CargoCRM.DTOs.UserDTOs;

public record UpdateUser
{
    public string UserName { get; init; }
    public string Password { get; init; }
    public string Role { get; init; }
}