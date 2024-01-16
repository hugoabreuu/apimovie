using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Configuração de contexto de banco de dados da aplicação
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder = this.ConfigureRelationshipSessao(builder);
    }

    /// <summary>
    /// Configura os relacionamentos da entidade <see cref="Sessao"/>.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    protected ModelBuilder ConfigureRelationshipSessao(ModelBuilder builder)
    {
        //define as chaves de relacionamento de N p/ N
        builder.Entity<Sessao>().HasKey(sessao =>
                    new
                    {
                        sessao.FilmeId,
                        sessao.CinemaId
                    });

        /*define que a entidade "Sessão" pode ter apenas um cinema
        e que a entidade "Cinema" pode ter várias cinemas
        onde as chaves que relaciona Sessao e cinema é o CinemaId*/
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);

        /*define que a entidade "Sessão" pode ter apenas um filme
        e que a entidade "filme" pode ter várias sessões
        onde as chaves que relaciona Sessao e cinema é o FilmeId*/
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        return builder;
    }
    /*define os modelos pertencentes ao domínio. 
    cada DbSet representa um tabela no banco de dados*/
    public DbSet<Filme>? Filmes { get; set; }
    public DbSet<Cinema>? Cinemas { get; set; }
    public DbSet<Endereco>? Enderecos { get; set; }
    public DbSet<Sessao>? Sessoes { get; set; }
}
