namespace CargoCRM.Models;

public class Package : EntityBase
{
    public int Id_trackcode { get; set; }
    public bool Is_sent { get; set; }
    public string Date_from { get; set; }
    public string Date_to { get; set; }
    
}