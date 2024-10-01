using Microsoft.AspNetCore.Mvc;
using GestioneGioco.Repository.Model;

namespace GestioneGioco.Repository.Abstractions;

public interface IGrigliaDiGiocoRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<GrigliaDiGioco> CreateGrigliaDiGioco(GrigliaDiGioco grigliaDiGioco);
    Task<GrigliaDiGioco> GetGrigliaDiGiocoById(int id);
    Task<bool> PutGrigliaDiGioco(GrigliaDiGioco grigliaDiGioco);


}
