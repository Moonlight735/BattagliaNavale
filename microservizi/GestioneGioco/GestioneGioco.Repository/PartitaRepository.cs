using GestioneGioco.Repository.Abstractions;
using GestioneGioco.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneGioco.Repository
{
    public class PartitaRepository : IPartitaRepository
    {
        private GestioneGiocoDbContext _gestionegiocoDbContext;

        private ILogger<PartitaRepository> _logger;

        public PartitaRepository(GestioneGiocoDbContext gestionegiocoDbContext, ILogger<PartitaRepository> logger)
        {
            _logger = logger;
            _gestionegiocoDbContext = gestionegiocoDbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _gestionegiocoDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<GrigliaPartita>> GetGrigliePartitaByPartita(int id)
        {
            var grigliePartita = await _gestionegiocoDbContext.GrigliaPartita
                .Where(gp => gp.IdPartita == id)
                .ToListAsync();

            return grigliePartita;
        }
        public async Task<GrigliaPartita> GetGrigliaPartitaByPartitaAndUtente(int id_partita, int id_utente)
        {
            var grigliaPartita = await _gestionegiocoDbContext.GrigliaPartita
                .Include(g => g.GrigliaDiGioco)
                .FirstOrDefaultAsync(gp => gp.IdPartita == id_partita && gp.IdUtente == id_utente);
                
            return grigliaPartita;
        }

        public async Task<Partita> CreatePartita(Partita partita)
        {

            // Aggiunge l'entità al contesto e salva le modifiche
            _gestionegiocoDbContext.Partita.Add(partita);
            await SaveChangesAsync();

            // Restituisce la nuova entità creata
            return partita;
        }
    }
}
