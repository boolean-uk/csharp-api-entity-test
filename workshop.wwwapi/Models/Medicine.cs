using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        [Column("id")]
        public int MedicineId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("description")]
        public string? Description { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }

    
}
