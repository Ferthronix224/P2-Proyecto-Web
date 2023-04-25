using Microsoft.AspNetCore.Mvc;
using TecNM.Project.Api.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Http;

namespace TecNM.Project.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<LoginDto>>>> GetAll()
    {
        var response = new Response<List<LoginDto>>
        {
            Data = await _loginService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<LoginDtoWP>>>Post([FromBody] LoginDtoWP loginDto)
    {
        var response = new Response<LoginDtoWP>
        {
            Data = await _loginService.SaveAsync(loginDto)
        };

        return Created($"/api/[controller]/{response.Data.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<LoginDto>>> GetById(int id)
    {
        var response = new Response<LoginDto>();
        if (!await _loginService.ProductCategoryExist(id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _loginService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<LoginDto>>> Update([FromBody] LoginDto loginDto)
    {
        var response = new Response<LoginDto>();
        if (!await _loginService.ProductCategoryExist(loginDto.id))
        {
            response.Errors.Add("No hay no existe");
            return NotFound(response);
        }

        response.Data = await _loginService.UpdateAsync(loginDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _loginService.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
}