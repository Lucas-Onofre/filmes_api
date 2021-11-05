using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        public string Nome { get; set; }
    }
}