namespace CargoCRM.Models;

public class User : EntityBase
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; }

}