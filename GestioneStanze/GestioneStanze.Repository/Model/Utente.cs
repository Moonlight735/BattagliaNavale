using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestioneStanze.Repository.Model
{
    [Table("utente")]
    public class Utente
    {
        [Key]
        [Column("id_utente")] // Specifichiamo il nome della colonna nel database
        public int Id { get; set; }

        [StringLength(30)]
        [Column("username")] // Specifichiamo il nome della colonna nel database
        public string? Username { get; set; }

        [StringLength(16)]
        [Column("password")] // Specifichiamo il nome della colonna nel database
        public string? Password { get; set; }

        [Column("ruolo")] // Specifichiamo il nome della colonna nel database
        public char? Ruolo { get; set; }

        [Column("id_stanza")] // Specifichiamo il nome della colonna nel database
        public int? IdStanza { get; set; }

        // Navigations
        [ForeignKey("IdStanza"), InverseProperty("Utenti")]
        public virtual Stanza? Stanza { get; set; }

        public virtual ICollection<Mossa>? Mosse { get; set; }
        public virtual GrigliaPartita? GrigliaPartita { get; set; }
    }
}





