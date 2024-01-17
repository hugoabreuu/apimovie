using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; } = string.Empty;

    #region relacionamentos
    public int EnderecoId { get; set; }
    public virtual Endereco? Endereco { get; set; } 
    public virtual ICollection<Sessao>? Sessoes { get; set; }
    #endregion
}
