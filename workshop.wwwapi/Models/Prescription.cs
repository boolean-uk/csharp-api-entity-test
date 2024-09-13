using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<MedicineOnPrescription>  medicines { get; set; } = new List<MedicineOnPrescription>();
    }
}
