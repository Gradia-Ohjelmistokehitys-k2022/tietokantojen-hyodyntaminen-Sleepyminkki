using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    [Table("Member")]
    public class Member
    {

         [Key]
         [Column("MemberId")]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? Birthday { get; set; }
    }
}

