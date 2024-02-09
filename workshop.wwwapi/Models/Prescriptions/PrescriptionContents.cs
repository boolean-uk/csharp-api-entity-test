using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models.Prescriptions
{
    [PrimaryKey(nameof(Prescription)+ "IdFK", nameof(Medicine) + "IdFK")]
    [Table("PrescriptionContents")]
    public class PrescriptionContents
    {
        [ForeignKey(nameof(Prescription)), Column("prescription_id_fk",Order = 0)]
        public int PrescriptionIdFK { get; set; }
        [ForeignKey(nameof(Medicine)), Column("medicine_id_fk", Order = 1)]
        public int MedicineIdFK { get; set; }
        public int Quantity { get; set; }

        public Prescription Prescription { get; set; } = null;
        public Medicine Medicine { get; set; } = null;
    }
}