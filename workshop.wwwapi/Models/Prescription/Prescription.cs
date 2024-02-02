using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Intermediaries;

namespace workshop.wwwapi.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        public IEnumerable<Medicine> Medicines { get; set; }

        [Column("appointment_id")]
        public int AppointmentId { get; set; }
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
