namespace WebApi.DTOs.EnderecoDTOs;

public class ReadEnderecoDTO
{
    public int Id { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public int Numero { get; set; }
    public DateTime Data_Consulta { get; set; } = DateTime.Now;
}
