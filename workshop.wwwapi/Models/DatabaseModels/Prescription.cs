using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("prescription")]
    public class Prescription
    {
        [Key, Column("prescription_id")]
        public int Id { get; set; }
        [Column("fk_doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        [Column("fk_patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [JsonIgnore]
        //public Appointment Appointment { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public List<PrescriptionMedicine> PrescriptionMedicine { get; set; } = new List<PrescriptionMedicine>();
    }
}
