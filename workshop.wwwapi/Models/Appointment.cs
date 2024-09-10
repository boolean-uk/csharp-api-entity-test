using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        [Column("Booking")]
        public DateTime Booking { get; set; }

        [Key]
        [ForeignKey("DoctorId")]
        [Column("DoctorId")]
        public int DoctorId { get; set; }

        [Key]
        [ForeignKey("PatientId")]
        [Column("PatientId")]
        public int PatientId { get; set; }

    }
}
