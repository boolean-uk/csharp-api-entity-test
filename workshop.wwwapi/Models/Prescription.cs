using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        [Column("id")] 
        public int Id { get; set; }


        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();

    }
}
