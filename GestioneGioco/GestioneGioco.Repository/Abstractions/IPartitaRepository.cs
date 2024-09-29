using GestioneGioco.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneGioco.Repository.Abstractions
{
    public interface IPartitaRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<List<GrigliaPartita>> GetGrigliePartitaByPartita(int id);
        Task<GrigliaPartita> GetGrigliaPartitaByPartitaAndUtente(int id_partita, int id_utente);
        Task<Partita> CreatePartita(Partita partita);
    }
}
