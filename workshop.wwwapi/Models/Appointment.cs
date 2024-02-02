using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("appointment_time")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        [ForeignKey("patient")]
        public int PatientId { get; set; }

    }
}
