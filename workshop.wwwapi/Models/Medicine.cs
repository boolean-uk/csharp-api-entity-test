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
        public string Name { get; set; }
    
        [Column("description")]
        public string Description { get; set; } // notes section and how to take it 

        public ICollection<PrescriptionMedicine> PrescriptionMedicine { get; set; }
    }

    
}
