using TecNM.Project.Core.Entities;

namespace TecNM.Project.Core.Dto;

public class LoginDto : DtoBase
{
    public string user { get; set; }
    
    public LoginDto(){}

    public LoginDto(Login login)
    {
        id = login.id;
        user = login.user;
    }
}