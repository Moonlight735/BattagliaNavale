using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GestioneUtente.Repository.Model;

namespace GestioneUtente.Repository.Model
{
    [Table("mossa")]

    public class Mossa
    {
        [Key]
        [Column("id_mossa")] // Specifichiamo il nome della colonna nel database
        public int Id { get; set; }

        [ForeignKey("GrigliaPartita"), InverseProperty("Mosse")]
        [Column("id_griglia_partita")] // Specifichiamo il nome della colonna nel database
        public int IdGrigliaPartita { get; set; }

        [ForeignKey("Utente"), InverseProperty("Mosse")]
        [Column("id_utente")] // Specifichiamo il nome della colonna nel database
        public int IdUtente { get; set; }

        [Column("numero_mossa")] // Specifichiamo il nome della colonna nel database
        public int NumeroMossa { get; set; }

        [Column("mossa_eseguita")] // Specifichiamo il nome della colonna nel database
        public string? MossaEseguita { get; set; }

        // Navigations
        public virtual GrigliaPartita? GrigliaPartita { get; set; }
        public virtual Utente? Utente { get; set; }
    }
}


