using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("medicine_ids")]
        public List<int> MedicineIds { get; set; } = [];
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Appointment Appointment { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public List<MedicinePrescription> MedicinePrecriptions { get; set; } = [];
        public List<Medicine> Medicines { get; set; } = [];
        
    }
}
