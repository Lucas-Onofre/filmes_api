using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FilmesApi.Models;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; } //a palavra reservada "virtual", neste caso, está dizendo que esta é uma propriedade LAZY
        public int EnderecoId { get; set; } 
        //public int EnderecoFK { get; set; }
        //public int GerenteFK { get; set; }
    }
}