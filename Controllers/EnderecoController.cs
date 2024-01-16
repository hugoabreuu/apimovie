using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.EnderecoDTOs;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly EnderecoService _service;
    public EnderecoController(EnderecoService service) =>
        this._service = service;

    [HttpGet]
    [Authorize]
    public IActionResult Get([FromQuery] int skip, [FromQuery] int take)
    {
        try
        {
            var readEnderecoDTOS = _service.Get(skip, take);
            return Ok(readEnderecoDTOS);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult Get(int id)
    {
        try
        {
            var readEnderecoDTO = _service.Get(id);
            return readEnderecoDTO != null ? Ok(readEnderecoDTO) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] CreateEnderecoDTO enderecoDTO)
    {
        try
        {
            var endereco = _service.Add(enderecoDTO);
            return CreatedAtAction(nameof(Get), new { Id = endereco.Id }, endereco);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put([FromBody] PutEnderecoDTO enderecoDTO, int id)
    {
        try
        {
            var endereco = _service.Put(id, enderecoDTO);
            return endereco != null ? NoContent() : StatusCode(500, "Um erro ocorreu ao alterar o endereco");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _service.Remove(id);
            return result ? NoContent() : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
