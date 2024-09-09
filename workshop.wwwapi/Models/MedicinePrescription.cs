using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicinePrescription")]
    [PrimaryKey("Id")]
    public class MedicinePrescription
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("medicineId")]
        public int MedicineId { get; set; }

        [ForeignKey("prescriptionId")]
        public int PrescriptionId { get; set; }
    }
}
