using Microsoft.AspNetCore.Mvc;
using Proyecto.Api.Repositories.Interfaces;
using Proyecto.Core.Entities;
using Proyecto.Core.Http;

namespace Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginRepository _loginRepository;
    
    public LoginController(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _loginRepository.GetAllAsync();
        var response = new Response<List<Login>>();
        response.Data = categories.ToList();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Login login)
    {
        if (login == null)
            return BadRequest();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _loginRepository.SaveAsync(login);

        return Created("created", created);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categories = await _loginRepository.GetById(id);
        var response = new Response<Login>();
        response.Data = categories;
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Login>>> Update([FromBody] Login login)
    {
        if (login == null)
            return BadRequest();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _loginRepository.UpdateAsync(login);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _loginRepository.DeleteAsync(new Login { id = id });

        return NoContent();
    }
}