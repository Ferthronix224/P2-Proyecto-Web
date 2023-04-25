using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Services;

public class ServiciosService : IServiciosService
{
    private readonly IServiciosRepository _serviciosRepository;

    public ServiciosService(IServiciosRepository serviciosRepository)
    {
        _serviciosRepository = serviciosRepository;
    }
    
    public async Task<ServiciosDto> SaveAsync(ServiciosDto serviciosDto)
    {
        var servicios = new Servicios()
        {
            name = serviciosDto.name,
            number = serviciosDto.number,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        servicios = await _serviciosRepository.SaveAsync(servicios);
        servicios.id = servicios.id;

        return serviciosDto;
    }

    public async Task<ServiciosDto> UpdateAsync(ServiciosDto serviciosDto)
    {
        var servicios = await _serviciosRepository.GetById(serviciosDto.id);

        if (servicios == null)
            throw new Exception("Service Not Found");
        
        servicios.name = serviciosDto.name;
        servicios.number = serviciosDto.number;
        servicios.UpdatedBy = "";
        servicios.UpdateDate = DateTime.Now;
        
        await _serviciosRepository.UpdateAsync(servicios);
        
        return serviciosDto;
    }

    public async Task<List<ServiciosDto>> GetAllAsync()
    {
        var categories = await _serviciosRepository.GetAllAsync();
        var loginDto = categories.Select(c => new ServiciosDto(c)).ToList();
        
        return loginDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var login = await _serviciosRepository.GetById(id);
        return (login != null);
    }

    public async Task<ServiciosDto> GetById(int id)
    {
        var servicios = await _serviciosRepository.GetById(id);
        if (servicios == null)
            throw new Exception("Service Not Found");
        var loginDto = new ServiciosDto(servicios);
        return loginDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _serviciosRepository.DeleteAsync(id);
    }
}