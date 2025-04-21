namespace CargoCRM.Models;

public class Package : EntityBase
{
    public string Name { get; set; }
    public int Id_trackcode { get; set; }
    public bool Is_sent { get; set; }
    public string Date_from { get; set; }
    public string Date_to { get; set; }
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; }
}