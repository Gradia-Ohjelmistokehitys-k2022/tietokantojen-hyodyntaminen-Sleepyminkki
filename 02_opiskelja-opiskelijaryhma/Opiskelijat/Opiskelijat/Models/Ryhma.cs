using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opiskelijat.Models
{
    [Table("Ryhma")]
    public class Ryhma
    {

        [Key]
        [Column("RyhmaId")]
        public int Id { get; set; }
        public string? RyhmaNimi { get; set; }
    }
}


