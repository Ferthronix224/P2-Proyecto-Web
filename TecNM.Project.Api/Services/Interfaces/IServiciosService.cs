using TecNM.Project.Core.Dto;

namespace TecNM.Project.Api.Services.Interfaces;

public interface IServiciosService
{
    Task<ServiciosDto> SaveAsync(ServiciosDto serviciosDto);
    
    //Metodo para actualizar las categorias de productos
    Task<ServiciosDto> UpdateAsync(ServiciosDto serviciosDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<ServiciosDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<ServiciosDto> GetById(int id);

    Task<bool> DeleteAsync(int id);
}