using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;
#nullable disable
public class Sessao
{
    [Required]
    public int? Capacidade { get; set; }
    [Required]
    public DateTime Inicio { get; set; }

    #region relacionamentos
    /**/
    [Required]
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    /**/
    [Required]
    public int CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
    #endregion
}
