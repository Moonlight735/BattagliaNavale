using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestioneStanze.Repository.Model
{
    [Table("griglia_partita")]
    public class GrigliaPartita
    {
        [Key]
        [Column("id_griglia_partita")] // Specifichiamo il nome della colonna nel database
        public int Id { get; set; }

        [ForeignKey("GrigliaDiGioco"), InverseProperty("GrigliePartite")]
        [Column("id_griglia_di_gioco")] // Specifichiamo il nome della colonna nel database
        public int IdGrigliaDiGioco { get; set; }

        [ForeignKey("Partita"), InverseProperty("GrigliePartite")]
        [Column("id_partita")] // Specifichiamo il nome della colonna nel database
        public int IdPartita { get; set; }

        [ForeignKey("Utente"), InverseProperty("GrigliePartite")]
        [Column("id_utente")] // Specifichiamo il nome della colonna nel database
        public int IdUtente { get; set; }

        [Column("schema_griglia_iniziale")] // Specifichiamo il nome della colonna nel database
        public string? SchemaGrigliaIniziale { get; set; }

        // Navigations
        public virtual GrigliaDiGioco? GrigliaDiGioco { get; set; }
        public virtual Partita? Partita { get; set; }
        public virtual ICollection<Mossa>? Mosse { get; set; }
        public virtual Utente? Utente { get; set; }
    }
}
