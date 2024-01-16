using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.UserDTOs;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;
    public UserController(UserService service) =>
        this._service = service;

    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateUserDTO userDTO)
    {
        try
        {
            var result = await _service.RegisteUserAsync(userDTO);

            if (result.Succeeded)
                return Ok("Usuário criado com sucesso!");

            return StatusCode(500, result.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Ocorreu um erro ao cadastrar o usuário!",
                stackTrace = ex.StackTrace
            });
        }
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
    {
        try
        {
            var token = await _service.LoginAsync(userLoginDTO);
            return Ok(token);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(new
            {
                message = ex.Message,
                stackTrace = ex.StackTrace
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Ocorreu um erro ao autenticar o usuário!",
                stackTrace = ex.StackTrace
            });
        }
    }
}
