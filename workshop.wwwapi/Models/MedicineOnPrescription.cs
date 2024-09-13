using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicine_on_prescription")]
    public class MedicineOnPrescription
    {
        [ForeignKey("medicine")]
        public int MedicineId { get; set; }
        public Medicine medicine { get; set; }
        [ForeignKey("prescription")]
        public int PrescriptionId { get; set; }
        public Prescription prescription { get; set; }
        public int DoseInMg { get; set; }
        public string Instruction { get; set; }
    }
}
