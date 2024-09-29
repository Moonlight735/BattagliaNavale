using GestioneTorneo.Business.Abstractions;
using GestioneTorneo.Repository.Abstractions;
using GestioneTorneo.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestioneTorneo.Business;
using GestioneTorneo.Repository;
using GestioneStanze.ClientHttp.Abstractions;
using GestioneStanze.ClientHttp;
using KafkaFlow.Producers;
using GestioneStanze.Shared;
using Microsoft.Extensions.Logging;

namespace GestioneTorneo.Business;

public class Business : IBusiness
{
    private ILogger<Business> _logger;
    private readonly IRepository _repository;
    private readonly IClientHttp _clientHttp;
    private readonly IClientHttp _gestionestanzeClientHttp;
    private IProducerAccessor _producerAccessor;

    public Business(IRepository repository, IClientHttp clientHttp, IClientHttp gestionestanzeClientHttp, IProducerAccessor producerAccessor, ILogger<Business> logger)
    {
        _clientHttp = clientHttp;
        _repository = repository;
        _gestionestanzeClientHttp = gestionestanzeClientHttp;
        _producerAccessor = producerAccessor;
        _logger = logger;
    }

    public async Task CambiaFaseDelGioco(int idStanza, string fase_del_gioco, CancellationToken cancellationToken = default)
    {
        var producer = _producerAccessor.GetProducer("gestionetorneo-producer");

        var gestionetorneoEvent = new GestioneTorneoEvent
        {
            Id = idStanza,
            Event = Event.ModificaFaseGioco,
            Info = fase_del_gioco
        };

        await producer.ProduceAsync("gestionetorneo-event-topic", Guid.NewGuid().ToString(), gestionetorneoEvent);
        _logger.LogInformation("CambiaFaseDelGioco con id {idStanza} e fase_del_gioco {fase_del_gioco} è stato pubblicato su Kafka", idStanza, fase_del_gioco);
        
    }


    // Implementazione  chiamata ClientHttp

    //public async Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco, CancellationToken cancellationToken = default)
    //{
    //    var response = await _gestionestanzeClientHttp.CambiaFaseDelGioco(id, fase_del_gioco, cancellationToken);
    //    return response;
    //}


    //public async Task<List<Stanza>?> GetStanze()
    //{
    //    var stanze = await _repository.GetStanze();
    //    return stanze;
    //}

    //public async Task<Stanza?> GetStanza(int id)
    //{
    //    var stanza = await _repository.GetStanza(id);
    //    return stanza;
    //}
    //public async Task<List<Stanza>?> GetStanzeNellaFase(string fase_del_gioco)
    //{
    //    var stanze = await _repository.GetStanzeNellaFase(fase_del_gioco);
    //    return stanze;
    //}

    //public async Task<bool> CambiaFaseDelGioco(int id, string fase_del_gioco)
    //{
    //    var result = await _repository.CambiaFaseDelGioco(id, fase_del_gioco);
    //    return result;
    //}
    //public async Task<Stanza?> GetStanzaPadre(int id_stanza_param)
    //{
    //    var stanzaPadre = await _repository.GetStanzaPadre(id_stanza_param);
    //    return stanzaPadre;
    //}
}
