using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace aspasp.Models
{
    public class Avion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Modele { get; set; }
        [Required]
        public int Capacite { get; set; }
    }
}