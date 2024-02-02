using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Column("prescription_id")]
        
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        [Column("appointment_date", TypeName = "date")]
        public DateTime AppointmentDate { get; set; }
    }
}
