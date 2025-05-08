using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("medicineperscriptions")]
    public class MedicinePerscription
    {
        [Column("medicineid")]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        [Column("perscriptionid")]
        [ForeignKey("Perscription")]
        public int PerscriptionId { get; set; }
    }
}
