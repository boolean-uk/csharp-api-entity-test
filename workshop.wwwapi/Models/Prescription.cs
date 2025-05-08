using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("medicine_id")]
        public ICollection<Medicine> Medicine { get; set; } = new List<Medicine>();
    }
}
