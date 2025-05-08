using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Column("instruction")]
        public string Instruction { get; set; }

        [ForeignKey(nameof(DocotrId))]
        public int DocotrId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        [ForeignKey("medicineId")]
        public int medicineId { get; set; }
    }
}
