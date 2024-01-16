using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.EnderecoDTOs;

public class PutEnderecoDTO
{
    [Required(ErrorMessage = "Logradouro obrigatório")]
    public string Logradouro { get; set; } = string.Empty;
    [Required(ErrorMessage = "Numero obrigatório")]
    [Range(1, 9999)]
    public int Numero { get; set; }
}
