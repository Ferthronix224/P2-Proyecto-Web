using TecNM.Project.Core.Dto;

namespace TecNM.Project.Api.Services.Interfaces;

public interface ICiudadesServices
{
    //Metodo para guardar categorias
    Task<CiudadesDto> SaveAsync(CiudadesDto ciudadesDto);
    
    //Metodo para actualizar las categorias de productos
    Task<CiudadesDto> UpdateAsync(CiudadesDto ciudadesDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<CiudadesDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<CiudadesDto> GetById(int id);

    Task<bool> DeleteAsync(int id);
}