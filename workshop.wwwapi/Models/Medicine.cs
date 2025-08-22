using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; } 
    }
}
