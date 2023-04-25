using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories.Interfaces;

public interface ILoginRepository
{
    //Metodo para guardar categorias
    Task<Login> SaveAsync(Login login);
    
    //Metodo para actualizar las categorias de productos
    Task<Login> UpdateAsync(Login login);
    
    //Metodo para retornar una lista de categorias
    Task<List<Login>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Login> GetById(int id);
}