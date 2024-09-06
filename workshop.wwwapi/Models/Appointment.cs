using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }
        [ForeignKey("Doctor")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [ForeignKey("Patient")]
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
