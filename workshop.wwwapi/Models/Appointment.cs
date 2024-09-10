using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("Doctor")]
        [Column("doctorId")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        [Column("patientId")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("prescriptionId")]
        public int? PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }
    }
}
