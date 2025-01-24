using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicine_presctiption")]
    public class MedicinePresctiption
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("medicine_id")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        [Column("prescription_id")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
