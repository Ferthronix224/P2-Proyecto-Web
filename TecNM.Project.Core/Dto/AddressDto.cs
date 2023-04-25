using TecNM.Project.Core.Entities;

namespace TecNM.Project.Core.Dto;

public class AddressDto : DtoBase
{
    public string name { get; set; }
    
    public AddressDto(){}

    public AddressDto(Address address)
    {
        id = address.id;
        name = address.name;
    }
}