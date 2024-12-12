using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opiskelijat.Models
{
    [Table("Opiskelija")]
    public class Opiskelija
    {

        [Key]
        [Column("OpiskelijaId")]
        public int Id { get; set; }
        public string? Nimi { get; set; }
        public int RyhmaId { get; set; }
        public string? Tunnus { get; set; }
    }
}

