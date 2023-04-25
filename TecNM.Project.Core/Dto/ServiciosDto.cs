using TecNM.Project.Core.Entities;

namespace TecNM.Project.Core.Dto;

public class ServiciosDto : DtoBase
{
    public string name { get; set; }
    public string number { get; set; }
    
    public ServiciosDto(){}

    public ServiciosDto(Servicios servicios)
    {
        id = servicios.id;
        name = servicios.name;
        number = servicios.number;
    }
}