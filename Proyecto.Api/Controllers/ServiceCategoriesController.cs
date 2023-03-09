using Microsoft.AspNetCore.Mvc;
using Proyecto.Api.Repositories.Interfaces;
using Proyecto.Core.Entities;
using Proyecto.Core.Http;

namespace Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceCategoriesController : ControllerBase
{
    private readonly IServiceCategoryRepository _ServiceCategoryRepository;
    
    public ServiceCategoriesController(IServiceCategoryRepository ServiceCategoryRepository)
    {
        _ServiceCategoryRepository = ServiceCategoryRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _ServiceCategoryRepository.GetAllAsync();
        var response = new Response<List<ServiceCategory>>();
        response.Data = categories.ToList();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ServiceCategory category)
    {
        if (category == null)
            return BadRequest();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _ServiceCategoryRepository.SaveAsync(category);

        return Created("created", created);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categories = await _ServiceCategoryRepository.GetById(id);
        var response = new Response<ServiceCategory>();
        response.Data = categories;
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ServiceCategory>>> Update([FromBody] ServiceCategory category)
    {
        if (category == null)
            return BadRequest();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _ServiceCategoryRepository.UpdateAsync(category);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _ServiceCategoryRepository.DeleteAsync(new ServiceCategory { id = id });

        return NoContent();
    }
}