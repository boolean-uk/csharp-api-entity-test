using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Collections.Generic;

namespace workshop.wwwapi.Models
{
    [Table("patients")]  
    public class Patient
    {
        [Key]
        [Column("id")]        
        public int Id { get; set; }

        [Column("full_name")]        
        public string FullName { get; set; }

        [InverseProperty("Patient")]
        public ICollection<Appointment> Appointments { get; set; }

    }
}
