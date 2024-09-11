using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("medicineprescriptions")]
    public class MedicinePrescription
    {

        [Column("id")]
        public int Id { get; set; }


        [Column("medicine_id")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } 


        [Column("prescription_id")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

    }
}
