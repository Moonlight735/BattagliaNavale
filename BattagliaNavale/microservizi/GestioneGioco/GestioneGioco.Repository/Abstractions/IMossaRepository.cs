using GestioneGioco.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneGioco.Repository.Abstractions
{
    public interface IMossaRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        //Task<bool> PutMossa(int id, Mossa mossa);
        Task<Mossa> CreateMossa(Mossa mossa);
    }
}
