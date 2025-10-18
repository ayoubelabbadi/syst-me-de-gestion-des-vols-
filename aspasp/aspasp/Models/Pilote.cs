using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeroport.Models
{
    [Table("Pilotes")]
    public class Pilote : Personne
    {
        [Required]
        [StringLength(20)]
        public string LicenceNumber { get; set; }

        [Range(0, int.MaxValue)]
        public int HeuresDeVol { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEmbauche { get; set; }
    }
}
