using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("patient_id")]
        public Guid PatientId { get; set; }

        [Column("doctor_id")]
        public Guid DoctorId { get; set; }

        [Column("appointment_date")]
        public DateTime AppointmentDate { get; set; }

        [Column("appointment_type")]
        public AppointmentType AppointmentType { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
