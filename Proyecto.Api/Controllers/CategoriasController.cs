using Microsoft.AspNetCore.Mvc;
using Proyecto.Api.Repositories.Interfaces;
using Proyecto.Core.Entities;
using Proyecto.Core.Http;

namespace Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController: ControllerBase
{
    private readonly ICategoriasRepository _categoriasRepository;
    
    public CategoriasController(ICategoriasRepository categoriasRepository)
    {
        _categoriasRepository = categoriasRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoriasRepository.GetAllAsync();
        var response = new Response<List<Categorias>>();
        response.Data = categories.ToList();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Categorias category)
    {
        if (category == null)
            return BadRequest();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _categoriasRepository.SaveAsync(category);

        return Created("created", created);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categories = await _categoriasRepository.GetById(id);
        var response = new Response<Categorias>();
        response.Data = categories;
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Categorias>>> Update([FromBody] Categorias category)
    {
        if (category == null)
            return BadRequest();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _categoriasRepository.UpdateAsync(category);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoriasRepository.DeleteAsync(new Categorias { id = id });

        return NoContent();
    }
}