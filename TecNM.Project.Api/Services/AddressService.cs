using TecNM.Project.Api.Repositories.Interfaces;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.Api.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }


    public async Task<AddressDto> SaveAsync(AddressDto addressDto)
    {
        var address = new Address()
        {
            name = addressDto.name,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        address = await _addressRepository.SaveAsync(address);
        address.id = address.id;

        return addressDto;
    }

    public async Task<AddressDto> UpdateAsync(AddressDto addressDto)
    {
        var address = await _addressRepository.GetById(addressDto.id);

        if (address == null)
            throw new Exception("Address Not Found");
        
        address.name = addressDto.name;
        address.UpdatedBy = "";
        address.UpdateDate = DateTime.Now;
        
        await _addressRepository.UpdateAsync(address);
        
        return addressDto;
    }

    public async Task<List<AddressDto>> GetAllAsync()
    {
        var categories = await _addressRepository.GetAllAsync();
        var addressDto = categories.Select(c => new AddressDto(c)).ToList();
        
        return addressDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var login = await _addressRepository.GetById(id);
        return (login != null);
    }

    public async Task<AddressDto> GetById(int id)
    {
        var address = await _addressRepository.GetById(id);
        if (address == null)
            throw new Exception("Address Not Found");
        var addressDto = new AddressDto(address);
        return addressDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _addressRepository.DeleteAsync(id);
    }
}