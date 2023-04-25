using Microsoft.AspNetCore.Mvc;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Http;

namespace TecNM.Project.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<CategoriesDto>>>> GetAll()
    {
        var response = new Response<List<CategoriesDto>>
        {
            Data = await _categoriesService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<CategoriesDto>>>Post([FromBody] CategoriesDto categoriesDto)
    {
        var response = new Response<CategoriesDto>
        {
            Data = await _categoriesService.SaveAsync(categoriesDto)
        };

        return Created($"/api/[controller]/{response.Data.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CategoriesDto>>> GetById(int id)
    {
        var response = new Response<CategoriesDto>();
        if (!await _categoriesService.ProductCategoryExist(id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _categoriesService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CategoriesDto>>> Update([FromBody] CategoriesDto categoriesDto)
    {
        var response = new Response<CategoriesDto>();
        if (!await _categoriesService.ProductCategoryExist(categoriesDto.id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _categoriesService.UpdateAsync(categoriesDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _categoriesService.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
}