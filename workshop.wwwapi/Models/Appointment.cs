using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Appointment")]
    [PrimaryKey("DoctorId", "PatientId", "Booking")]
    public class Appointment
    {
        [Column("Booking")]
        public DateTime Booking { get; set; }
        [Column("DoctorId")]
        public int DoctorId { get; set; }
        [Column("PatientId")]
        public int PatientId { get; set; }
    
        [NotMapped]
        public Doctor? Doctor { get; set; }
        [NotMapped]
        public Patient? Patient { get; set; }


    }
}
