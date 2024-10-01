using GestioneGioco.Repository.Abstractions;
using GestioneGioco.Repository.Model;
using GestioneGioco.Shared;
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
    public class MossaRepository : IMossaRepository
    {
        private GestioneGiocoDbContext _gestionegiocoDbContext;

        private ILogger<MossaRepository> _logger;

        public MossaRepository(GestioneGiocoDbContext gestionegiocoDbContext, ILogger<MossaRepository> logger)
        {
            _logger = logger;
            _gestionegiocoDbContext = gestionegiocoDbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _gestionegiocoDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<Mossa> CreateMossa(Mossa mossa)
        {

            // Aggiunge l'entità al contesto e salva le modifiche
            _gestionegiocoDbContext.Mossa.Add(mossa);
            await SaveChangesAsync();

            // Restituisce la nuova entità creata
            return mossa;
        }
        
        //public async Task<bool> PutMossa(int id, Mossa mossa)
        //{
        //    if (id != mossa.Id)
        //    {
        //        return false;
        //    }

        //    _gestionegiocoDbContext.Entry(mossa).State = EntityState.Modified;
        //    try
        //    {
        //        await _gestionegiocoDbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MossaExists(id))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return true;

        //}

        private bool MossaExists(int id)
        {
            return _gestionegiocoDbContext.Mossa.Any(e => e.Id == id);
        }
    }
}
