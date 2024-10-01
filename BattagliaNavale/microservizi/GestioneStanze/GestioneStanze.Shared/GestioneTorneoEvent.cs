namespace GestioneStanze.Shared;

public enum Event
{
    ModificaFaseGioco
    
}

public class GestioneTorneoEvent
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public string Info { get; set; }
}