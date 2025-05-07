namespace CargoCRM.DTOs.UserDTOs;

public record PatchUpdateUser
{
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string? Role { get; init; }
}