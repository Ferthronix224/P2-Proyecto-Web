namespace TecNM.Project.Core.Entities;

public class Login : EntityBase
{
    public int id { get; set; }
    public string user { get; set; }
    public string password { get; set; }
}