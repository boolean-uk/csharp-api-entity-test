using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.MedicineModels;
using workshop.wwwapi.Models.PrescriptionModels;

namespace workshop.wwwapi.Models.PrescriptionMedicineModels
{
    [Table("PrescriptionMedicine")]
    public class PrescriptionMedicine
    {
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public Medicine Medicine { get; set; }
        public Prescription Prescription { get; set; }
    }
}
