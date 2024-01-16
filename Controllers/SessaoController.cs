using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.SessaoDTO;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessaoController : ControllerBase
{
    private readonly SessaoService _service;
    public SessaoController(SessaoService service) =>
        this._service = service;

    [HttpGet]
    [Authorize]
    public IActionResult Get([FromQuery] int skip, [FromQuery] int take)
    {
        try
        {
            var readSessaoDTOs = _service.GetAll(skip, take);
            return Ok(readSessaoDTOs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpGet("{filmeId}/{cinemaId}")]
    [Authorize]
    public IActionResult Get(short filmeId, short cinemaId)
    {
        try
        {
            var readSessaoDTO = _service.Get(filmeId, cinemaId);
            return readSessaoDTO != null ? Ok(readSessaoDTO) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost]
    [Authorize]
    public IActionResult Post(CreateSessaoDTO sessaoDTO)
    {
        try
        {
            var sessao = _service.Add(sessaoDTO);
            return CreatedAtAction(nameof(Get), new { sessao.FilmeId, sessao.CinemaId }, sessao);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
