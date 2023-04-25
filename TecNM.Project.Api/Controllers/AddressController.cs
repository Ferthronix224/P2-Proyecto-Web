using Microsoft.AspNetCore.Mvc;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Http;

namespace TecNM.Project.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<AddressDto>>>> GetAll()
    {
        var response = new Response<List<AddressDto>>
        {
            Data = await _addressService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<AddressDto>>>Post([FromBody] AddressDto addressDto)
    {
        var response = new Response<AddressDto>
        {
            Data = await _addressService.SaveAsync(addressDto)
        };

        return Created($"/api/[controller]/{response.Data.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<AddressDto>>> GetById(int id)
    {
        var response = new Response<AddressDto>();
        if (!await _addressService.ProductCategoryExist(id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _addressService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<AddressDto>>> Update([FromBody] AddressDto addressDto)
    {
        var response = new Response<AddressDto>();
        if (!await _addressService.ProductCategoryExist(addressDto.id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _addressService.UpdateAsync(addressDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _addressService.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
}