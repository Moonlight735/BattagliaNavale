using GestioneUtente.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace GestioneUtente.Repository
{
    public class GestioneUtenteDbContext : DbContext
    {
        public GestioneUtenteDbContext(DbContextOptions<GestioneUtenteDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=host.docker.internal,2433;Database=gestione_torneo;User Id=sa;Password=p4ssw0rD;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder torea)
        {
            // configurazione del modello tramite API fluent
        }


        // DbSet per ogni entità
        public DbSet<Utente> Utente { get; set; }
        public DbSet<Stanza> Stanza { get; set; }
        public DbSet<Partita> Partita { get; set; }
        public DbSet<GrigliaDiGioco> GrigliaDiGioco { get; set; }
        public DbSet<GrigliaPartita> GrigliaPartita { get; set; }
        public DbSet<Mossa> Mossa { get; set; }
    }
}
