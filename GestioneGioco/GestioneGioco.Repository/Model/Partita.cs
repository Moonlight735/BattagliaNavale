using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneGioco.Repository.Model
{
    [Table("partita")]
    public class Partita
    {
        [Key]
        [Column("id_partita")] // Specifichiamo il nome della colonna nel database
        public int Id { get; set; }

        // Navigation
        public virtual ICollection<Stanza>? Stanze { get; set; }
        public virtual ICollection<GrigliaPartita>? GrigliePartite { get; set; }
    }
}
