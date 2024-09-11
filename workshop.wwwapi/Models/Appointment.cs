using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Appointments")]
    public class Appointment
    {
        
        [Column("Booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("Doctor")]
        [Column("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor doctor { get; set; }

        [ForeignKey("Patient")]
        [Column("PatientId")]
        public int PatientId { get; set; }
        public Patient patient { get; set; }

    }
}
