using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Required]
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [JsonIgnore]

        [ForeignKey(nameof(PatientId) + "," + nameof(DoctorId))]
        public Appointment Appointment { get; set; }
        [JsonIgnore]

        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new();
    }
}
