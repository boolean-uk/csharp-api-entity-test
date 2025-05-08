using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Prescription
    {
        [Column("prescription_id")]
        public int Id { get; set; }
        public List<MedicinePrescription> Medicines { get; set; } = new List<MedicinePrescription>();
    }
}
