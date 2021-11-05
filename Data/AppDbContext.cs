using FilmesApi.Models;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>() // a entidade endereço
                .HasOne(endereco => endereco.Cinema) //possui uma propriedade Cinema
                .WithOne(cinema => cinema.Endereco)  // e esta propriedade Cinema possui um Endereço
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); // e o Cinema possui referência a Endereço através de EnderecoId (ForeignKey)
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
    }
}