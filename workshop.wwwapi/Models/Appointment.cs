using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonInclude]

        public virtual Doctor Doctor { get; set; } = null;
        [JsonInclude]

        public virtual Patient Patient { get; set; } = null;

    }

    public class PostAppointment()
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }  
        public DateTime Booking { get; set; }
    }
}
