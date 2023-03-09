using Proyecto.Core.Entities;

namespace Proyecto.Api.Repositories.Interfaces;

public interface ILoginRepository
{
    //Metodo para guardar categorias
    Task<bool> SaveAsync(Login login);
    
    //Metodo para actualizar las categorias de servicios
    Task<bool> UpdateAsync(Login login);
    
    //Metodo para retornar una lista de categorias
    Task<IEnumerable<Login>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(Login login);
    
    //Metodo para obtener una categoria por id
    Task<Login> GetById(int id);
}