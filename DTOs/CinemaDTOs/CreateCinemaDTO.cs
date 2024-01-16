using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.CinemaDTOs;

public class CreateCinemaDTO
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; } = string.Empty;
    [Required]
    public int EnderecoId { get; set; }
}
