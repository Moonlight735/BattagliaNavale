using GestioneGioco.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneGioco.Repository.Abstractions
{
    public interface IGrigliaPartitaRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<GrigliaPartita> GetGrigliaPartita(int id);
        Task<bool> PutGrigliaPartita(GrigliaPartita grigliaPartita);
    }
}
