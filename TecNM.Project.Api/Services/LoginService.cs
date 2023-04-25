using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Services;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;

    public LoginService(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }
    
    public async Task<LoginDtoWP> SaveAsync(LoginDtoWP loginDto)
    {
        var login = new Login()
        {
            user = loginDto.user,
            password = loginDto.password,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        login = await _loginRepository.SaveAsync(login);
        login.id = login.id;

        return loginDto;
    }

    public async Task<LoginDto> UpdateAsync(LoginDto loginDto)
    {
        var login = await _loginRepository.GetById(loginDto.id);

        if (login == null)
            throw new Exception("City Not Found");
        
        login.user = loginDto.user;
        login.UpdatedBy = "";
        login.UpdateDate = DateTime.Now;
        
        await _loginRepository.UpdateAsync(login);
        
        return loginDto;
    }

    public async Task<List<LoginDto>> GetAllAsync()
    {
        var categories = await _loginRepository.GetAllAsync();
        var loginDto = categories.Select(c => new LoginDto(c)).ToList();
        
        return loginDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var login = await _loginRepository.GetById(id);
        return (login != null);
    }

    public async Task<LoginDto> GetById(int id)
    {
        var login = await _loginRepository.GetById(id);
        if (login == null)
            throw new Exception("City Not Found");
        var loginDto = new LoginDto(login);
        return loginDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _loginRepository.DeleteAsync(id);
    }
}