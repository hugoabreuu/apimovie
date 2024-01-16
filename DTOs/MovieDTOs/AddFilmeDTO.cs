using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.MovieDTOs;

public class AddFilmeDTO
{
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? Genero { get; set; }
    [Required]
    public int Duracao { get; set; }
    [Required]
    public int Ano_Lancamento { get; set; }
}
