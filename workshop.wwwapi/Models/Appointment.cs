using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [ForeignKey("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("patient_id")]
        public int PatientId { get; set; }

        [Column("appointment_date")]
        public DateTime AppointmentDate { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
