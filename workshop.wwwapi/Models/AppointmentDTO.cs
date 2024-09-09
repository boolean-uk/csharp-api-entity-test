using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("APPOINTMENT")]
    public class AppointmentDTO
    {
        [Key]
        [Column("APPOINTMENT_DATE")]
        public DateTime Booking { get; set; }

        [ForeignKey("DOCTOR")]
        [Column("DOCTOR_ID")]
        public int DoctorId { get; set; }

        [ForeignKey("PATIENT")]
        [Column("PATIENT_ID")]
        public int PatientId { get; set; }
    }
}
