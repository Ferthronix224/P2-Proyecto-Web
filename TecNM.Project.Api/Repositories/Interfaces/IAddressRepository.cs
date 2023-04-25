using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Repositories.Interfaces;

public interface IAddressRepository
{
    //Metodo para guardar categorias
    Task<Address> SaveAsync(Address address);
    
    //Metodo para actualizar las categorias de productos
    Task<Address> UpdateAsync(Address address);
    
    //Metodo para retornar una lista de categorias
    Task<List<Address>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Address> GetById(int id);
}