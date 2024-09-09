using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("perscriptionMedicines")]
    public class PerscriptionMedicine
    {
        [Column("medicineId")]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
        [Column("perscriptionId")]
        [ForeignKey("Perscription")]
        public int PerscriptionId { get; set; }
        public Perscription? Perscription { get; set; }
    }
}
