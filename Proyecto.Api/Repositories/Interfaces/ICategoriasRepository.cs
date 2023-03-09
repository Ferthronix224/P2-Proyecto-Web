using Proyecto.Core.Entities;

namespace Proyecto.Api.Repositories.Interfaces;

public interface ICategoriasRepository
{
    //Metodo para guardar categorias
    Task<bool> SaveAsync(Categorias category);
    
    //Metodo para actualizar las categorias de servicios
    Task<bool> UpdateAsync(Categorias category);
    
    //Metodo para retornar una lista de categorias
    Task<IEnumerable<Categorias>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(Categorias category);
    
    //Metodo para obtener una categoria por id
    Task<Categorias> GetById(int id);
}