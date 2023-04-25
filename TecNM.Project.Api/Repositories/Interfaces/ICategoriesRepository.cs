using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories.Interfaces;

public interface ICaregoriesRepository
{
    //Metodo para guardar categorias
    Task<Categories> SaveAsync(Categories categories);
    
    //Metodo para actualizar las categorias de productos
    Task<Categories> UpdateAsync(Categories categories);
    
    //Metodo para retornar una lista de categorias
    Task<List<Categories>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Categories> GetById(int id);
}