using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Logradouro { get; set; } = string.Empty;
        [Required]
        public int Numero { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}