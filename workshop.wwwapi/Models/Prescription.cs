using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [ForeignKey("Doctor")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [ForeignKey("Patient")]
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
