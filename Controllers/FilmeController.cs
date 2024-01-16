using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.MovieDTOs;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmeController : ControllerBase
{
    private readonly MovieService _service;
    public FilmeController(MovieService service) =>
        this._service = service;

    [HttpGet]
    [Authorize]
    public IActionResult Get([FromQuery] int skip, [FromQuery] int take)
    {
        try
        {
            var getFilmeDTOs = _service.Get(skip, take);
            return Ok(getFilmeDTOs);
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
            var getFilmeDTO = _service.Get(id);
            return getFilmeDTO != null ? Ok(getFilmeDTO) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] AddFilmeDTO filmeDTO)
    {
        try
        {
            var filme = _service.Add(filmeDTO);
            return CreatedAtAction(nameof(Get), new { Id = filme.FilmeId }, filme);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put([FromBody] PutFilmeDTO filmeDTO, int id)
    {
        try
        {
            var filme = _service.Put(id, filmeDTO);
            return filme != null ? NoContent() : StatusCode(500, "Um erro ocorreu ao alterar o filme");
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
