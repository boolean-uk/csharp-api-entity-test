using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    [Table("PrescriptionMedicine")]
    public class PrescriptionMedicine
    {
        [Key]
        public int Id { get; set; }

        [Column("prescriptionId")]
        [ForeignKey("prescriptionId")]
        public int PrescriptionId { get; set; }
        
        public Prescription Prescription { get; set; }

        [Column("medicineId")]
        [ForeignKey("medicineId")]
        public int MedicineId { get; set; }
        
        public Medicine Medicine { get; set; }
        [Column("instruction")]
        public string Instruction { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
