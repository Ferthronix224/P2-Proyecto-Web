using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories.Interfaces;

public interface IServiciosRepository
{
    //Metodo para guardar categorias
    Task<Servicios> SaveAsync(Servicios servicios);
    
    //Metodo para actualizar las categorias de productos
    Task<Servicios> UpdateAsync(Servicios servicios);
    
    //Metodo para retornar una lista de categorias
    Task<List<Servicios>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Servicios> GetById(int id);
}