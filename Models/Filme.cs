using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Filme
{
    [Key]
    public int FilmeId { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? Genero { get; set; }
    [Required]
    [MinLength(70)]
    public int Duracao { get; set; }
    [Required]
    public int Ano_Lancamento { get; set; }

    #region relacionamentos
    public virtual ICollection<Sessao> Sessoes { get; set; }
    #endregion
}
