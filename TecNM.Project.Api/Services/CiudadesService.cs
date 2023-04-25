using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Services;

public class CiudadesService : ICiudadesServices
{
    private readonly ICiudadesRepository _ciudadesRepository;

    public CiudadesService(ICiudadesRepository ciudadesRepository)
    {
        _ciudadesRepository = ciudadesRepository;
    }
    
    public async Task<CiudadesDto> SaveAsync(CiudadesDto ciudadesDto)
    {
        var ciudad = new Ciudades()
        {
            name = ciudadesDto.name,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        ciudad = await _ciudadesRepository.SaveAsync(ciudad);
        ciudad.id = ciudad.id;

        return ciudadesDto;
    }

    public async Task<CiudadesDto> UpdateAsync(CiudadesDto ciudadesDto)
    {
        var ciudad = await _ciudadesRepository.GetById(ciudadesDto.id);

        if (ciudad == null)
            throw new Exception("City Not Found");
        
        ciudad.name = ciudadesDto.name;
        ciudad.UpdatedBy = "";
        ciudad.UpdateDate = DateTime.Now;
        
        await _ciudadesRepository.UpdateAsync(ciudad);
        
        return ciudadesDto;
    }

    public async Task<List<CiudadesDto>> GetAllAsync()
    {
        var categories = await _ciudadesRepository.GetAllAsync();
        var ciudadesDto = categories.Select(c => new CiudadesDto(c)).ToList();
        
        return ciudadesDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var ciudad = await _ciudadesRepository.GetById(id);
        return (ciudad != null);
    }

    public async Task<CiudadesDto> GetById(int id)
    {
        var ciudad = await _ciudadesRepository.GetById(id);
        if (ciudad == null)
            throw new Exception("City Not Found");
        var ciudadDto = new CiudadesDto(ciudad);
        return ciudadDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _ciudadesRepository.DeleteAsync(id);
    }
}