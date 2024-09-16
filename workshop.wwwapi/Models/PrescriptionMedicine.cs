using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescription_medicines")]
    public class PrescriptionMedicine
    {
        [Column("prescriptionid")]
        public int PrescriptionId { get; set; }
        [ForeignKey("PrescriptionId")]
        public Prescription Prescription { get; set; }
        [Column("medicineid")]
        public int MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("notes")]
        public string? Notes { get; set; }
    }
}