using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{

    [Table("prescript")]
    public class PrescriptionMedicine
    {

        [ForeignKey("medicine_id")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [ForeignKey("prescription_id")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public int Quatity { get; set; }    
        public string Note { get; set; }    

    }
}
