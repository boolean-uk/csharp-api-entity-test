using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }

    }
}
