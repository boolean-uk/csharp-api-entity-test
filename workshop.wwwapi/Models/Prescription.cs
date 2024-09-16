using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("medicine_id")]
        public List<Medicine> Medicines { get; set; }
    }
}
