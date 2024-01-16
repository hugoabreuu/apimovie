using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.SessaoDTO;

public class CreateSessaoDTO
{
    [Required]
    [Range(20,250)]
    public int Capacidade { get; set; }
    [Required]
    public DateTime Inicio { get; set; }
    [Required]
    public int FilmeId { get; set; }
    [Required]
    public int CinemaId { get; set; }
}
