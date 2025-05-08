using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class MedicinePrescription
    {
        [Column("perscriptionid")]
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        [Column("medicineid")]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
    }
}
