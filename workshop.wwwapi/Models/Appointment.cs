using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("booking_time")]
        public DateTime Booking { get; set; }

        [ForeignKey("Doctor")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        [Column("patient_id")]
        public int PatientId { get; set; }

    }
}
