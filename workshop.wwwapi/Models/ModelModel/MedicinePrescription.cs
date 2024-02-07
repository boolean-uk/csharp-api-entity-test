using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicine_prescriptions")]
    [PrimaryKey("Id")]
    public class MedicinePrescription
    {
        [Column("mp_id")]
        public int Id { get; set; }

        [Column("mp_medicine_id")]
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Column("mp_prescription_id")]
        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
