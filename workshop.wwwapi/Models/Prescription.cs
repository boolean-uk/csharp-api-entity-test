using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    [Table("Prescriptions")]
    public class Prescription
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("patientid")]
        public int PatientId { get; set; }
        [Column("doctorid")]
        public int DoctorId { get; set; }
        [ForeignKey("PatientId, DoctorId")]
        public Appointment? Appointment { get; set; }


        [Column("medecineprescriptions")]
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
