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

public class GrigliaDiGiocoRepository : IGrigliaDiGiocoRepository
{
    private GestioneGiocoDbContext _gestionegiocoDbContext;

    private ILogger<GrigliaDiGiocoRepository> _logger;

    public GrigliaDiGiocoRepository(GestioneGiocoDbContext gestionegiocoDbContext, ILogger<GrigliaDiGiocoRepository> logger)
    {
        _logger = logger;
        _gestionegiocoDbContext = gestionegiocoDbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _gestionegiocoDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<GrigliaDiGioco> CreateGrigliaDiGioco(GrigliaDiGioco grigliaDiGioco)
    {
       
        // Aggiunge l'entità al contesto e salva le modifiche
        _gestionegiocoDbContext.GrigliaDiGioco.Add(grigliaDiGioco);
        await SaveChangesAsync();

        // Restituisce la nuova entità creata
        return grigliaDiGioco;
    }

    public async Task<GrigliaDiGioco> GetGrigliaDiGiocoById(int id)
    {
        var grigliaDiGioco = _gestionegiocoDbContext.GrigliaDiGioco.FindAsync(id);

        return await grigliaDiGioco;
    }

    public async Task<bool> PutGrigliaDiGioco(GrigliaDiGioco grigliaDiGioco)
    {


        _gestionegiocoDbContext.Entry(grigliaDiGioco).State = EntityState.Modified;
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
}