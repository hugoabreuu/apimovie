namespace WebApi.DTOs.SessaoDTO;

public class ReadSessaoDTO
{
    public int? Capacidade { get; set; }    
    public DateTime Inicio { get; set; }    
    public int FilmeId { get; set; }    
    public int CinemaId { get; set; }
}
