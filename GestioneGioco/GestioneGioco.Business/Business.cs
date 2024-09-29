using GestioneGioco.Business.Abstractions;
using GestioneGioco.Repository.Abstractions;
using GestioneGioco.Repository.Model;
using GestioneGioco.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneGioco.Business;
using GestioneGioco.Repository;
using Newtonsoft.Json;
using System.Drawing;


namespace GestioneGioco.Business;

public class Business : IBusiness
{
    private readonly IGrigliaDiGiocoRepository _grigliaDiGiocoRepository;
    private readonly IGrigliaPartitaRepository _grigliaPartitaRepository;
    private readonly IMossaRepository _mossaRepository;
    private readonly IPartitaRepository _partitaRepository;

    public Business(IGrigliaDiGiocoRepository grigliaDiGiocoRepository, IGrigliaPartitaRepository grigliaPartitaRepository, IMossaRepository mossaRepository, IPartitaRepository partitaRepository)
    {

        _grigliaDiGiocoRepository = grigliaDiGiocoRepository;
        _grigliaPartitaRepository = grigliaPartitaRepository;
        _mossaRepository = mossaRepository;
        _partitaRepository = partitaRepository;
    }

    public async Task<Partita> CreatePartita()
    {
        var partita = new Partita();
        // Utilizza il repository per creare la griglia
        var nuovaPartita = await _partitaRepository.CreatePartita(partita);

        return nuovaPartita;
    }

    public async Task<GrigliaDiGioco> CreateGrigliaDiGioco (GrigliaDiGiocoDto grigliaDiGiocoDto)
    {
        // Crea l'entità GrigliaDiGioco
        var grigliaDiGioco = new GrigliaDiGioco
        {
            SchemaGrigliaAvversario = grigliaDiGiocoDto.GrigliaDiGioco
        };

        // Utilizza il repository per creare la griglia
        var nuovaGriglia = await _grigliaDiGiocoRepository.CreateGrigliaDiGioco(grigliaDiGioco);

        return nuovaGriglia;
    }

    public async Task<GrigliaPartita> GetGrigliaPartita(int id)
    {
        var grigliaPartita = await _grigliaPartitaRepository.GetGrigliaPartita(id);
                                           
        return grigliaPartita;
    }
    public async Task<bool> VerificaGrigliaPartita(int id)
    {
        var grigliaPartita = await _grigliaPartitaRepository.GetGrigliaPartita(id);
        string grigliaDiGiocojson = grigliaPartita.SchemaGrigliaNavi;
        Griglia griglia = new Griglia(grigliaDiGiocojson);
        bool esito = griglia.VerificaGriglia(); //TO DO: VerificaGriglia corpo corretto
        return esito;
    }

    //public async Task<bool> PutMossa(int id, Mossa mossa)
    //{
    //    var result = await _mossaRepository.PutMossa(id,mossa);
    //    return result;
    //}

    public async Task<Mossa> CreateMossa(MossaDto mossaDto)
    {
        // Crea l'entità Mossa
        var mossa = new Mossa
        {
            IdGrigliaPartita = mossaDto.IdGrigliaPartita, 
            IdUtente = mossaDto.IdUtente,
            NumeroMossa = mossaDto.NumeroMossa,
            MossaEseguita = mossaDto.MossaEseguita,

        };

        // Utilizza il repository per creare la mossa
        var nuovaMossa = await _mossaRepository.CreateMossa(mossa);

        return nuovaMossa;
    }
    public async Task<List<GrigliaPartita>> GetGrigliePartitaByPartita(int id)
    {
        var grigliePartita = await _partitaRepository.GetGrigliePartitaByPartita(id);
            
        return grigliePartita;
    }
    public async Task<GrigliaPartita> GetGrigliaPartitaByPartitaAndUtente(int id_partita, int id_utente)
    {
        var grigliaPartita = await _partitaRepository.GetGrigliaPartitaByPartitaAndUtente(id_partita, id_utente);

        return grigliaPartita;
    }
    public async Task<string> EseguiMossaSuAvversario(MossaDto mossaDto)
    {
        //Recupero della griglia partita dell’avversario
        var grigliaPartita = await _partitaRepository.GetGrigliaPartitaByPartitaAndUtente(mossaDto.IdPartita, mossaDto.IdUtenteAvversario);

        //Applicazione della mossa alla griglia dell’avversario ottenendo un esito
        string grigliaDiGiocojson = grigliaPartita.SchemaGrigliaNavi;
        Griglia griglia = new Griglia(grigliaDiGiocojson);
        string esito = griglia.GestisciColpo(mossaDto.MossaEseguita);

        //Aggiorno la griglia dell’avversario presente nel db con questa nuova griglia
        string grigliaDiGiocojsonAggiornata = new GrigliaData(griglia).ToJson();
        grigliaPartita.SchemaGrigliaNavi = grigliaDiGiocojsonAggiornata;
        await _grigliaPartitaRepository.PutGrigliaPartita(grigliaPartita);

        //Applico nella mia griglia di gioco la mossa fatta(in base all’esito)
        var grigliaPartitaUtente = await _partitaRepository.GetGrigliaPartitaByPartitaAndUtente(mossaDto.IdPartita, mossaDto.IdUtente);
        var grigliaDiGiocoUtente = grigliaPartitaUtente.GrigliaDiGioco;
        string grigliaDiGiocojsonUtente = grigliaDiGiocoUtente.SchemaGrigliaAvversario;
        Griglia grigliaUtente = new Griglia(grigliaDiGiocojsonUtente); 
        griglia.InserisciColpo(mossaDto.MossaEseguita, esito);

        //Salvo nel db la griglia di gioco appena aggiornata(al punto precedente)
        string grigliaDiGiocojsonAggiornataUtente = new GrigliaData(griglia).ToJson();
        grigliaDiGiocoUtente.SchemaGrigliaAvversario = grigliaDiGiocojsonAggiornataUtente;
        await _grigliaDiGiocoRepository.PutGrigliaDiGioco(grigliaDiGiocoUtente);

        //Restituisce l'esito dell'operazione
        return esito; 

    }

    public async Task<bool> VintoPartita(int id_utente, int id_partita)
    {
        var grigliaPartitaUtente = await _partitaRepository.GetGrigliaPartitaByPartitaAndUtente(id_partita, id_utente);
        var grigliaDiGiocoUtente = grigliaPartitaUtente.GrigliaDiGioco;
        string grigliaDiGiocojsonUtente = grigliaDiGiocoUtente.SchemaGrigliaAvversario; //Voglio sapere se abbatto navi avversario
        Griglia grigliaSituazioneAvversario = new Griglia(grigliaDiGiocojsonUtente);
        return grigliaSituazioneAvversario.VintoPartita();

    }

}
