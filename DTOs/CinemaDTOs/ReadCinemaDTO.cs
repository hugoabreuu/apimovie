using WebApi.DTOs.EnderecoDTOs;

namespace WebApi.DTOs.CinemaDTOs;

public class ReadCinemaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ReadEnderecoDTO Endereco { get; set; }
    public DateTime Data_Consulta { get; set; } = DateTime.Now;
}
