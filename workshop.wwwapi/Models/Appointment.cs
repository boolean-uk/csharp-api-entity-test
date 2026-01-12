using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("appointment_id")]
        public int Id { get; set; }

        [Column("booking_date")]
        public DateTime Booking { get; set; } = DateTime.UtcNow;

        [ForeignKey("Doctor")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        [Column("patient_id")]
        public int PatientId { get; set; }


        // Navigation properties, used for Entity Framework to establish relationships and the includes in the queries
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
    }
}
