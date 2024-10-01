using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneGioco.Repository.Model
{
    [Table("griglia_di_gioco")]
    public class GrigliaDiGioco
    {
        [Key]
        [Column("id_griglia_di_gioco")]
        public int Id { get; set; }

        [Column("schema_griglia_avversario")]
        public string? SchemaGrigliaAvversario { get; set; }

        // Navigation
        public virtual ICollection<GrigliaPartita>? GrigliePartite { get; set; }
    }
}
