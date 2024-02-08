using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("perscriptions")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int PrescriptionId { get; set; }
        [Column("notes")]
        public string Notes { get; set; }

        // foreign keys
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("appointment_id")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
