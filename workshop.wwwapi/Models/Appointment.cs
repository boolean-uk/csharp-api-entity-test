using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {

        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("doctors")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("patients")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
