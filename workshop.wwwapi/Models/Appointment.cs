using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        [Column("appointment_id")]
        public int Id { get; set; }
        [Column("booking_time")]
        public DateTime Booking { get; set; }

        [ForeignKey("doctor_id")]
        [Column("doctor_id")] 
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("patient_id")]
        [Column("Patientid")] 
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
