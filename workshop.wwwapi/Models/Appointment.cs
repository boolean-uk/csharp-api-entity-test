using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking_date")]
        public DateTime Booking { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("prescription_id")]
        public int PrescriptionId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Prescription Prescription { get; set; }
        
    }
}
