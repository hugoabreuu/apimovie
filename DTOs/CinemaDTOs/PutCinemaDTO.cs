using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.CinemaDTOs;

public class PutCinemaDTO
{
    [Required]
    public string Nome { get; set; }= string.Empty;
}
