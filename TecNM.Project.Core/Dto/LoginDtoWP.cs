using TecNM.Project.Core.Entities;

namespace TecNM.Project.Core.Dto;

public class LoginDtoWP : DtoBase
{
    public string user { get; set; }
    public string password { get; set; }
    
    public LoginDtoWP(){}

    public LoginDtoWP(Login login)
    {
        id = login.id;
        user = login.user;
        password = login.password;
    }
}