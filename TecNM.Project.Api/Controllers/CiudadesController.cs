using Microsoft.AspNetCore.Mvc;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Http;

namespace TecNM.Project.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CiudadesController : ControllerBase
{
    private readonly ICiudadesServices _ciudadesServices;

    public CiudadesController(ICiudadesServices ciudadesServices)
    {
        _ciudadesServices = ciudadesServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<CiudadesDto>>>> GetAll()
    {
        var response = new Response<List<CiudadesDto>>
        {
            Data = await _ciudadesServices.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<CiudadesDto>>>Post([FromBody] CiudadesDto ciudadesDto)
    {
        var response = new Response<CiudadesDto>
        {
            Data = await _ciudadesServices.SaveAsync(ciudadesDto)
        };

        return Created($"/api/[controller]/{response.Data.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CiudadesDto>>> GetById(int id)
    {
        var response = new Response<CiudadesDto>();
        if (!await _ciudadesServices.ProductCategoryExist(id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _ciudadesServices.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CiudadesDto>>> Update([FromBody] CiudadesDto ciudadesDto)
    {
        var response = new Response<CiudadesDto>();
        if (!await _ciudadesServices.ProductCategoryExist(ciudadesDto.id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _ciudadesServices.UpdateAsync(ciudadesDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _ciudadesServices.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
}