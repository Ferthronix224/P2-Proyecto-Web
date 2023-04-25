using Microsoft.AspNetCore.Mvc;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Http;

namespace TecNM.Project.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiciosController : ControllerBase
{
    private readonly IServiciosService _serviciosService;

    public ServiciosController(IServiciosService serviciosService)
    {
        _serviciosService = serviciosService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ServiciosDto>>>> GetAll()
    {
        var response = new Response<List<ServiciosDto>>
        {
            Data = await _serviciosService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ServiciosDto>>>Post([FromBody] ServiciosDto serviciosDto)
    {
        var response = new Response<ServiciosDto>
        {
            Data = await _serviciosService.SaveAsync(serviciosDto)
        };

        return Created($"/api/[controller]/{response.Data.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ServiciosDto>>> GetById(int id)
    {
        var response = new Response<ServiciosDto>();
        if (!await _serviciosService.ProductCategoryExist(id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _serviciosService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ServiciosDto>>> Update([FromBody] ServiciosDto serviciosDto)
    {
        var response = new Response<ServiciosDto>();
        if (!await _serviciosService.ProductCategoryExist(serviciosDto.id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _serviciosService.UpdateAsync(serviciosDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _serviciosService.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
}