using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.UserDTOs;

public class CreateUserDTO
{
    [Required]
    public string UserName { get; set; }
    [DataType(dataType: DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    public string RePassword { get; set; }
    public DateTime BirthDate { get; set; }
}
