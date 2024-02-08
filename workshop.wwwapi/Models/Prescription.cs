using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }

        public List<PrescriptionMedicine> Medicines { get; set; }
        public Appointment Appointment { get; set; }
    }
}
