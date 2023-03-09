using Proyecto.Core.Entities;

namespace Proyecto.Api.Repositories.Interfaces;

public interface IServiceCategoryRepository
{
    //Metodo para guardar categorias
    Task<bool> SaveAsync(ServiceCategory category);
    
    //Metodo para actualizar las categorias de servicios
    Task<bool> UpdateAsync(ServiceCategory category);
    
    //Metodo para retornar una lista de categorias
    Task<IEnumerable<ServiceCategory>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(ServiceCategory category);
    
    //Metodo para obtener una categoria por id
    Task<ServiceCategory> GetById(int id);
}