namespace CargoCRM.Models;

public class EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; }
}