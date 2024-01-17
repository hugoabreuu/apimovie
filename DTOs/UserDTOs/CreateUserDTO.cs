using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.UserDTOs;

public class CreateUserDTO
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [DataType(dataType: DataType.Password)]
    public string Password { get; set; }= string.Empty;
    [Compare("Password")]
    public string RePassword { get; set; }= string.Empty;
    public DateTime BirthDate { get; set; }
}
