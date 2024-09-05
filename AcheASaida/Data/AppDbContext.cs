using AcheASaida.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AcheASaida.Data;

public class AppDbContext(IConfiguration configuracao) : DbContext
{
    private DbSet<Grupo> Grupos { get; set; }
    private DbSet<Labirinto> Labirintos { get; set; }
    private DbSet<Vertice> Vertices { get; set; }
    private DbSet<InfoLabirinto> InfoLabirintos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(configuracao.GetConnectionString("SqliteConnection"));
        base.OnConfiguring(optionsBuilder);
    }
}