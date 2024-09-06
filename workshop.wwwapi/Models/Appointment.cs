using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("patient_id")]
        public Guid PatientId { get; set; }

        [Column("doctor_id")]
        public Guid DoctorId { get; set; }

        [Column("appointment_date")]
        public DateTime AppointmentDate { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

    }
}
