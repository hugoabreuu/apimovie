
using WebApi.DTOs.SessaoDTO;

namespace WebApi.DTOs.MovieDTOs;

public class GetFilmeDTO
{
    public int FilmeId { get; set; }
    public string? Nome { get; set; }
    public string? Genero { get; set; }
    public int Duracao { get; set; }
    public int Ano_Lancamento { get; set; }
    public ICollection<ReadSessaoDTO>? Sessoes { get; set; }
    public DateTime Data_Consulta { get; set; } = DateTime.Now;
}
