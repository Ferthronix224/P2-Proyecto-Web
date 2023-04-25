using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories.Interfaces;

public interface ICiudadesRepository
{
    //Metodo para guardar categorias
    Task<Ciudades> SaveAsync(Ciudades ciudades);
    
    //Metodo para actualizar las categorias de productos
    Task<Ciudades> UpdateAsync(Ciudades ciudades);
    
    //Metodo para retornar una lista de categorias
    Task<List<Ciudades>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Ciudades> GetById(int id);
}