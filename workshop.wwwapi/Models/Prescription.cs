using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("doctor_id")]
        [ForeignKey("doctor_id")]
        public int DoctorId { get; set; }

        [Column("patient_id")]
        [ForeignKey("patient_id")]
        public int PatientId { get; set; }
    }
}
