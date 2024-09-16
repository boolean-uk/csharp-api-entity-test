using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("medicines")]
    public class Medicine : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        [Column("instruction")]
        public string Instruction { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("prescription_id")]
        public List<Prescription> Prescriptions { get; }
    }
}
