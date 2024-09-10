using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicinePrescription")]
    public class MedicinePrescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("MedicineId")]
        public int MedicineId { get; set; }

        [ForeignKey("PrescriptionId")]
        public int PrescriptionId { get; set; }
    }
}
