using TecNM.Project.Core.Dto;

namespace TecNM.Project.Api.Services.Interfaces;

public interface ILoginService
{
    //Metodo para guardar categorias
    Task<LoginDtoWP> SaveAsync(LoginDtoWP loginDto);
    
    //Metodo para actualizar las categorias de productos
    Task<LoginDto> UpdateAsync(LoginDto loginDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<LoginDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<LoginDto> GetById(int id);

    Task<bool> DeleteAsync(int id);
}