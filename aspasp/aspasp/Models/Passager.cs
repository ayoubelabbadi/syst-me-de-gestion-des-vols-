using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeroport.Models
{
    [Table("Passagers")]
    public class Passager : Personne
    {
        [Required]
        [StringLength(20)]
        public string NumeroPasseport { get; set; }

        [StringLength(50)]
        public string Nationalite { get; set; }

        public bool FrequentFlyer { get; set; }
    }
}
