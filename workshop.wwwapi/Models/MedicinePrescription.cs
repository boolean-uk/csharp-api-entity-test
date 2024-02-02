using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicine_prescription")]
    public class MedicinePrescription
    {

        [Column("medicine_id", Order = 0)]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        [Column("prescription_id", Order = 1)]
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
    }
}
