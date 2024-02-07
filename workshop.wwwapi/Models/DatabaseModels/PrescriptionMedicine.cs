using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    public class PrescriptionMedicine
    {
        [Column("fk_medicine_id")]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        [Column("fk_prescription_id")]
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("notes")]
        public string Notes { get; set; }

        public Medicine Medicine { get; set; }
        public Prescription Prescription { get; set; }
    }
}
