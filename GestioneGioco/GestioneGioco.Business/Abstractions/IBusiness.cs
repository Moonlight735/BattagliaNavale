using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using GestioneGioco.Repository.Abstractions;
using GestioneGioco.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using GestioneGioco.Repository;
using static GestioneGioco.Business.Business;
using GestioneGioco.Shared;

namespace GestioneGioco.Business.Abstractions;
public interface IBusiness

{
    Task<Partita> CreatePartita();
    Task<GrigliaDiGioco> CreateGrigliaDiGioco(GrigliaDiGiocoDto grigliaDiGiocoDto);
    Task<GrigliaPartita> GetGrigliaPartita(int id);
    Task<bool> VerificaGrigliaPartita(int id);
    //Task<bool> PutMossa(int id, Mossa mossa);
    Task<Mossa> CreateMossa(MossaDto mossaDto);
    Task<List<GrigliaPartita>> GetGrigliePartitaByPartita(int id);
    Task<GrigliaPartita> GetGrigliaPartitaByPartitaAndUtente(int id_partita, int id_utente);
    Task<string> EseguiMossaSuAvversario(MossaDto mossaDto);
    Task<bool> VintoPartita(int id_utente, int id_partita);
}
