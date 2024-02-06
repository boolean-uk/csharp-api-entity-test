using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Models
{

    [Table("medicine")]
    public class Medicine
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("prescription_id")]
        public ICollection<Prescription> Prescription { get; set; } = new List<Prescription>();

        [Column("instructions")]
        public string Instructions { get; set; }

    }
}
