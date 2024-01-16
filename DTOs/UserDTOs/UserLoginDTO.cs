using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.UserDTOs;

public class UserLoginDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
