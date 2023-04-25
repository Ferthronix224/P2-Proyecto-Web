using TecNM.Project.Core.Dto;

namespace TecNM.Project.Api.Services.Interfaces;

public interface ICategoriesService
{
    //Metodo para guardar categorias
    Task<CategoriesDto> SaveAsync(CategoriesDto categoriesDto);
    
    //Metodo para actualizar las categorias de productos
    Task<CategoriesDto> UpdateAsync(CategoriesDto categoriesDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<CategoriesDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<CategoriesDto> GetById(int id);

    Task<bool> DeleteAsync(int id);
}