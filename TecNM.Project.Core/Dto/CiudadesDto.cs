using TecNM.Project.Core.Entities;

namespace TecNM.Project.Core.Dto;

public class CiudadesDto : DtoBase
{
    public string name { get; set; }
    
    public CiudadesDto(){}

    public CiudadesDto(Ciudades ciudad)
    {
        id = ciudad.id;
        name = ciudad.name;
    }
}