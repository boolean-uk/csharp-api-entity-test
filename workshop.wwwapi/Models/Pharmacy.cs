using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("pharmacy")]
    public class Pharmacy
    {
        [ForeignKey("Medicine")]
        [Column("medicine_id")]
        public int MedicineId { get; set; }
        [ForeignKey("Prescription")]
        [Column("prescription_id")]
        public int PrescriptionId { get; set; }
    }
}
