using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestioneUtente.Repository.Model;

namespace GestioneUtente.Repository.Model
{
    [Table("stanza")]
    public class Stanza
    {
        [Key]
        [Column("id_stanza")] // Specifichiamo il nome della colonna nel database
        public int Id { get; set; }

        [Column("id_stanza_padre")] // Specifichiamo il nome della colonna nel database
        public int? IdStanzaPadre { get; set; }

        [Column("id_partita")] // Specifichiamo il nome della colonna nel database
        public int? IdPartita { get; set; }

        [StringLength(255)]
        [Column("nome_stanza")] // Specifichiamo il nome della colonna nel database
        public string? Nome { get; set; }

        [Column("livello")] // Specifichiamo il nome della colonna nel database
        public int? Livello { get; set; }

        [StringLength(2)]
        [Column("fase_del_gioco")] // Specifichiamo il nome della colonna nel database
        public string? FaseDelGioco { get; set; }

        // Navigations
        [ForeignKey("IdPartita"), InverseProperty("Stanze")]
        public virtual Partita? Partita { get; set; }

        [ForeignKey("IdStanzaPadre"), InverseProperty("StanzeFiglie")]
        public virtual Stanza? StanzaPadre { get; set; }

        [InverseProperty("StanzaPadre")]
        public virtual ICollection<Stanza>? StanzeFiglie { get; set; }
        public virtual ICollection<Utente>? Utenti { get; set; } = new List<Utente>();
    }
}

