using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column("instruction")]
        public string Instruction { get; set; }
        public List<PerscriptionMedicine> PerscriptionMedicines { get; set; }

    }
}
