namespace Proyecto.Core.Entities;

public class EntityBase
{
    public int id { get; set; }
    public bool isDeleted { get; set; }
    public string createdBy { get; set; }
    public DateTime updatedBy { get; set; }
    public DateTime updateDate { get; set; }
}