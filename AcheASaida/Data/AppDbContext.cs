using AcheASaida.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AcheASaida.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuracao;

        public AppDbContext(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Labirinto> Labirintos { get; set; }
        public DbSet<Vertice> Vertices { get; set; }
        public DbSet<InfoLabirinto> InfoLabirintos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuracao.GetConnectionString("SqliteConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}