using TecNM.Project.Core.Entities;

namespace TecNM.Project.Core.Dto;

public class CategoriesDto : DtoBase
{
    public string name { get; set; }
    
    public CategoriesDto(){}

    public CategoriesDto(Categories categories)
    {
        id = categories.id;
        name = categories.name;
    }
}