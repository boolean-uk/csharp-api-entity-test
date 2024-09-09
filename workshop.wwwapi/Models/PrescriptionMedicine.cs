using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescription_medicines")]
    public class PrescriptionMedicine
    {
        //[Column("prescription_id")]
        [Column("prescription_id"), ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        [Column("medicine_id"), ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        public Prescription Prescription { get; set; }
        public Medicine Medicine { get; set; }
    }
}
