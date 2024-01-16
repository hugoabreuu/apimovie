using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.CinemaDTOs;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CinemaController : ControllerBase
{
    private readonly CinemaService _service;
    public CinemaController(CinemaService service) =>
        this._service = service;
        
    [HttpGet]
    [Authorize]
    public IActionResult Get([FromQuery] int skip, [FromQuery] int take)
    {
        try
        {
            var cinemas = _service.Get(skip, take);
            return Ok(cinemas);
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
            var readCinemaDTO = _service.Get(id);
            return readCinemaDTO != null ? Ok(readCinemaDTO) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] CreateCinemaDTO cinemaDTO)
    {
        try
        {
            var cinema = _service.Add(cinemaDTO);
            return CreatedAtAction(nameof(Get), new { Id = cinema.Id }, cinema);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put([FromBody] PutCinemaDTO cinemaDTO, int id)
    {
        try
        {
            var cinema = _service.Put(id, cinemaDTO);
            return cinema != null ? NoContent() : StatusCode(500, "Um erro ocorreu ao alterar o cinema!");
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
