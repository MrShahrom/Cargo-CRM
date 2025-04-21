namespace CargoCRM.Models;

public class TrackCode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Id_customer { get; set; }
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; }
}