using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicineprescriptions")]
    public class MedicinePrescription
    {

        [Column("id")]
        public int Id { get; set; }


        [Column("medicine_id")]
        public int MedicineId { get; set; }


        [Column("prescription_id")]
        public int PrescriptionId { get; set; }


        public Medicine Medicine { get; set; } 
        public Prescription Prescription { get; set; }

    }
}