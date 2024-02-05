using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Models.JunctionTable
{
    [Table("prescription_medicine")]
    public class PrescriptionMedicine
    {
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        [Column("amount")]
        public int Amount { get; set; }

        [Column("instructions")]
        [MaxLength(511)]
        public string Instructions { get; set; }
    }
}
