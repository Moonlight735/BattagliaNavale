using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using GestioneGioco.Repository.Abstractions;
using GestioneGioco.Repository.Model;
using GestioneGioco.Repository;
using Newtonsoft.Json;
using GestioneGioco.Shared;


namespace GestioneGioco.Repository;

public class GrigliaPartitaRepository : IGrigliaPartitaRepository
{
    private GestioneGiocoDbContext _gestionegiocoDbContext;

    private ILogger<GrigliaPartitaRepository> _logger;

    public GrigliaPartitaRepository(GestioneGiocoDbContext gestionegiocoDbContext, ILogger<GrigliaPartitaRepository> logger)
    {
        _logger = logger;
        _gestionegiocoDbContext = gestionegiocoDbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _gestionegiocoDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<GrigliaPartita> GetGrigliaPartita(int id)
    {
        var grigliaPartita = await _gestionegiocoDbContext.GrigliaPartita
                                           .Include(g => g.GrigliaDiGioco)
                                           //.Include(g => g.Partita)
                                           //.Include(g => g.Utente)
                                           //.Include(g => g.Mosse)
                                           .FirstOrDefaultAsync(g => g.Id == id);

        return grigliaPartita;
    }

    public async Task<bool> PutGrigliaPartita(GrigliaPartita grigliaPartita)
    {
        

        _gestionegiocoDbContext.Entry(grigliaPartita).State = EntityState.Modified;
        try
        {
            await _gestionegiocoDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
           
        }

        return true;

    }
    //private bool GrigliaPartitaExists(int id)
    //{
    //    return _gestionegiocoDbContext.GrigliaPartita.Any(e => e.Id == id);
    //}

}