using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [ForeignKey("Appointment"), Column(Order = 0)]
        public int DoctorId { get; set; }
        [ForeignKey("Appointment"), Column(Order = 1)]
        public int PatientId { get; set; }

        public List<PrescriptionMedicine> Medicines { get; set; }
    }
}
