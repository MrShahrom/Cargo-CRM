namespace CargoCRM.DTOs.UserDTOs;

public record UserDto
{
    public int Id { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string Role { get; init; }
};