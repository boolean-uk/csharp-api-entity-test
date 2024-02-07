using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescription_medicines")]
    public class PrescriptionMedicine
    {
        //[Column("prescription_id")]
        [Key, ForeignKey("Prescription"), Column("prescription_id", Order = 0)]
        public int PrescriptionId { get; set; }
        [ForeignKey("Medicine"), Column("medicine_id", Order = 1)]
        public int MedicineId { get; set; }

        public Prescription Prescription { get; set; }
        public Medicine Medicine { get; set; }
    }
}
