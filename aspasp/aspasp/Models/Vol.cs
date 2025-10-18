using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspasp.Models;

namespace Aeroport.Models
{
    [Table("Vols")]
    public class Vol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string VilleDepart { get; set; }

        [Required]
        [StringLength(100)]
        public string VilleArrivee { get; set; }

        [Required]
        public DateTime DateVol { get; set; }

        [Required]
        public int AvionId { get; set; }

        [ForeignKey("AvionId")]
        public Avion Avion { get; set; }

        [Required]
        public int PiloteId { get; set; }

        [ForeignKey("PiloteId")]
        public Pilote Pilote { get; set; }
    }
}
