using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine
    {
        
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("quantity")]
        [Required]
        public int Quantity {  get; set; }
        [Column ("notes")]
        public string Notes { get; set; }
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; } = new List<MedicinePrescription>();
    }
}
