using KafkaFlow;
using GestioneStanze.Business.Abstractions;
using GestioneStanze.Shared;

namespace GestioneStanze.Api;

public class GestioneTorneoHandler(ILogger<GestioneTorneoHandler> logger, IServiceProvider serviceProvider)
    : IMessageHandler<GestioneTorneoEvent>
{
    public async Task Handle(IMessageContext context, GestioneTorneoEvent message)
    {
        using var scope = serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBusiness>();
        switch (message.Event)
        {
            case Event.ModificaFaseGioco:
                
                await repository.CambiaFaseDelGioco(message.Id, message.Info);
                break;
            
        }
    }
}