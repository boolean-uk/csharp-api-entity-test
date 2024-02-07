using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicine")]
    public class Medicine
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [ForeignKey("prescriptionId")]
        public int PrescriptionId { get; set; }
    }
}
