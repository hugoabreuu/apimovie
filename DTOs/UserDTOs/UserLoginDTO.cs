using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.UserDTOs;

public class UserLoginDTO
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; }= string.Empty;
}
