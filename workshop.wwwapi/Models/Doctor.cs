using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace workshop.wwwapi.Models
{
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [InverseProperty("Doctor")]
        public ICollection<Appointment> Appointments { get; set; }
    }
}
