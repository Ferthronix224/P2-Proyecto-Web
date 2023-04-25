using TecNM.Project.Core.Dto;

namespace TecNM.Project.Api.Services.Interfaces;

public interface IAddressService
{
    Task<AddressDto> SaveAsync(AddressDto addressDto);
    
    //Metodo para actualizar las categorias de productos
    Task<AddressDto> UpdateAsync(AddressDto addressDto);
    
    //Metodo para retornar una lista de categorias
    Task<List<AddressDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<AddressDto> GetById(int id);

    Task<bool> DeleteAsync(int id);
}