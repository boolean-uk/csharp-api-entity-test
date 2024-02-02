using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("booking_date_time")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]
        [ForeignKey("doctors")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        [ForeignKey("patients")]
        public int PatientId { get; set; }
        public virtual Doctor Doctor { get; set; } = null;
        public virtual Patient Patient { get; set; } = null;

    }
}
