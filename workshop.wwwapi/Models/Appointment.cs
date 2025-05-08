using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public enum AppointmentType
    {
        ONLINE,
        PERSON
    }
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]
        [ForeignKey("doctors")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        [ForeignKey("patients")]
        public int PatientId { get; set; }
        [Column("prescription_id")]
        [ForeignKey("prescriptions")]
        public int? PrescriptionId { get; set; }
        [Column("appointment_type")]
        public AppointmentType Type { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Prescription Prescription { get; set; } 
        
     }
}
